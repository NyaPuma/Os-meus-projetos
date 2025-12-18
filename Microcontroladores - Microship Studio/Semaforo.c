#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdio.h>

#define FCLK_TIMRT0 64E-6
#define PRESCALER 0x05
#define MEUTIMER 15625
#define F_CPU 16E6
#define FCLK_USART F_CPU/16
#define BAUD 9600
#define MY_BAUD (FCLK_USART/BAUD)-1

#define GREEN  0
#define YELLOW 1
#define RED    2
#define STOP   3

unsigned char state = STOP;
unsigned char next_state = YELLOW;
unsigned char rx_buffer = 0;
unsigned char usart_flag = 0;
unsigned char GreenDelay = 2;
unsigned char YellowDelay = 1;
unsigned char RedDelay = 3;

void usart_init(unsigned int baud_rate);
void io_config(void);
void timers_config(void);
void timer1_delay(unsigned int delay);

int main(void)
{
	io_config();
	timers_config();
	usart_init(MY_BAUD);
	sei();
	
	while(1)
	{
		switch (state)
		{
			case GREEN:

			PORTB &= ~(1<<PORTB2);
			PORTB |= (1<<PORTB0);

			timer1_delay(GreenDelay);
			if(usart_flag) break;
			state = next_state;
			next_state++;
			break;

			case YELLOW:
			
			PORTB &= ~(1<<PORTB0);
			PORTB |= (1<<PORTB1);

			timer1_delay(YellowDelay);
			if(usart_flag) break;
			state = next_state;
			next_state++;
			break;

			case RED:

			PORTB &= ~(1<<PORTB1);
			PORTB |= (1<<PORTB2);

			timer1_delay(RedDelay);
			if(usart_flag) break;
			next_state = GREEN;
			state = next_state;
			next_state++;
			break;
			
			case STOP:
			PORTB &= ~(1<<PORTB0);
			PORTB &= ~(1<<PORTB1);
			PORTB &= ~(1<<PORTB2);
			break;
			default:
			break;
		}
	}
	return 0;
}

ISR(USART_RX_vect)
{
	rx_buffer = UDR0;
	
	if('I' == rx_buffer)
	{
		state = GREEN;
		next_state = YELLOW;
		usart_flag = 0;
	}
	
	if('+' == rx_buffer && STOP == state)
	{
		GreenDelay++;
		if (GreenDelay > 4)
		{
			GreenDelay--;
		}
		
		RedDelay++;
		if (RedDelay > 4)
		{
			RedDelay--;
		}
		
	}
	
	if ('-' == rx_buffer && STOP == state)
	{
		if((GreenDelay == 1) || (RedDelay == 1))
		{
			return;
		}
		else
		{
			GreenDelay--;
			RedDelay--;

		}
	}
	else if('P' == rx_buffer)
	{
		state = STOP;
		usart_flag = 1;
	}
	
}
void io_config(void)
{
	DDRB = (1<<DDB0) | (1<<DDB1) | (1<<DDB2);
	DDRC = (0<<DDC0);
}

void timers_config(void)
{
	TCNT1H = 0x00;
	TCNT1L = 0x00;
	TCCR1A = 0x00;
	TCCR1B = 0x00;
}

void timer1_delay(unsigned int delay)
{
	int timer;
	
	timer = MEUTIMER * delay;
	if (timer > 65535)
	return;
	timer = 0xFFFF - timer;
	
	TCNT1 = timer;
	TCCR1B = PRESCALER;
	
	while(0 ==(TIFR1&(0x01<<TOV1)))
	{
		if (0 == (PINC&(1<<PORTC0))&& GREEN == state)
		{
			return;
		}
	}
	TCCR1B = 0;
	TIFR1 = 0x01<<TOV1;
}

void usart_init(unsigned int baud_rate)
{
	UCSR0A = 0x00;
	UCSR0B = (1<<RXEN0) | (1<<RXCIE0);
	UCSR0C = (1<<UPM01)|(1<<UCSZ01)|(1<<UCSZ00);
	UBRR0H = (baud_rate>>8);
	UBRR0L = baud_rate;
}
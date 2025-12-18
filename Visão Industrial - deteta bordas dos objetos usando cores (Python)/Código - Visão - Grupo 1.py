import cv2
import numpy as np

def detect_color(frame):
    # Convertendo o quadro para o espaço de cor HSV
    hsv_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

    # Definindo os intervalos de cor para cada cor
    lower_red = np.array([0, 150, 60])
    upper_red = np.array([15, 255, 255])

    lower_yellow = np.array([20, 100, 60])
    upper_yellow = np.array([40, 255, 255])

    lower_green = np.array([40, 100, 60])
    upper_green = np.array([60, 255, 255])

    lower_blue = np.array([90, 180, 180])
    upper_blue = np.array([150, 255, 255])

    # Criando máscaras para cada cor
    mask_red = cv2.inRange(hsv_frame, lower_red, upper_red)
    mask_yellow = cv2.inRange(hsv_frame, lower_yellow, upper_yellow)
    mask_green = cv2.inRange(hsv_frame, lower_green, upper_green)
    mask_blue = cv2.inRange(hsv_frame, lower_blue, upper_blue)

    # Detectando contornos nas máscaras
    contours_red, _ = cv2.findContours(mask_red, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    contours_yellow, _ = cv2.findContours(mask_yellow, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    contours_green, _ = cv2.findContours(mask_green, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    contours_blue, _ = cv2.findContours(mask_blue, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

    # Desenhando contornos no quadro original
    cv2.drawContours(frame, contours_red, -1, (0, 0, 255), 2)
    cv2.drawContours(frame, contours_yellow, -1, (0, 255, 255), 2)
    cv2.drawContours(frame, contours_green, -1, (0, 255, 0), 2)
    cv2.drawContours(frame, contours_blue, -1, (255, 0, 0), 2)

    cv2.imshow('Detecção de Cores', frame)

# Inicializando a captura de vídeo (substitua o índice pela câmera externa desejada)
cap = cv2.VideoCapture(1)

while True:
    ret, frame = cap.read()

    if not ret:
        break

    detect_color(frame)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()

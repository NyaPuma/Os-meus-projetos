/**
 * @file app.js
 * @description Ficheiro principal de lógica e interatividade do website Laranja Miau.
 * * Contém a lógica de inicialização de todas as páginas:
 * - Autenticação e Gestão de Sessão (Login, Registo, Logout, Restrições de Acesso)
 * - Interações da Página Inicial (Carrosséis, Navegação de Categorias, Favoritos, Comprar)
 * - Interações da Página do Carrinho (Cálculo de Preços, Quantidades)
 * - Interações da Página de Perfil (Navegação de Menu)
 * - Lógica Comum (Newsletter Footer, Botões de Header)
 */

document.addEventListener('DOMContentLoaded', () => {
    // 0. Verifica e Restringe o Acesso a páginas protegidas (deve ser a primeira verificação)
    if (checkAccessRestriction()) return; 

    // A. Interações Comuns a todas as páginas
    setupFooterForm();
    handleAuthButtons();
    
    // B. Interações da Página Inicial (index.html)
    if (document.querySelector('.website-container')) {
        setupCategoryNavigation();
        setupProtectedInteractions();
        setupVerMaisLinks(); 
        setupSearchBarSimulation(); 
        
        // Inicializar todos os carrosséis por ID de secção
        setupCarousel('alimentacao');
        setupCarousel('brinquedos');
        setupCarousel('acessorios');
        setupCarousel('higiene');
    }

    // C. Interações da Página do Carrinho (carrinho.html)
    if (document.querySelector('.carrinho-layout')) {
        setupCartInteractions();
    }
    
    // D. Interações da Página de Perfil (perfil.html)
    if (document.querySelector('.perfil-layout')) {
        setupProfileInteractions();
        setupLogout();
    }
    
    // E. Interações da Página de Login/Registo (login.html)
    if (document.getElementById('login-form-area')) {
        setupAuthFormInteractions();
    }
});


/* ================================================= */
/* === FUNÇÕES DE AUTENTICAÇÃO E RESTRICÃO DE ACESSO === */
/* ================================================= */

/**
 * Define o estado de autenticação no Local Storage e guarda/remove dados do utilizador.
 * @param {boolean} isAuthenticated - O novo estado de autenticação.
 * @param {string} [userName=''] - O nome do utilizador, usado para simular o avatar.
 * @returns {void}
 */
function setAuthStatus(isAuthenticated, userName = '') {
    localStorage.setItem('isAuthenticated', isAuthenticated ? 'true' : 'false');
    
    if (isAuthenticated) {
        localStorage.setItem('userName', userName);
        // Simulação de URL de avatar com base no nome do utilizador
        localStorage.setItem('userAvatarUrl', `https://i.pravatar.cc/300?u=${userName.toLowerCase().replace(/\s/g, '')}`);
    } else {
        localStorage.removeItem('userName');
        localStorage.removeItem('userAvatarUrl');
    }
}

/**
 * Obtém o nome do utilizador a partir do Local Storage.
 * @returns {string|null} O nome do utilizador se autenticado, ou `null`.
 */
function getUserName() {
    return localStorage.getItem('userName');
}

/**
 * Verifica o estado de autenticação do utilizador.
 * @returns {boolean} `true` se autenticado, `false` caso contrário.
 */
function isUserAuthenticated() {
    return localStorage.getItem('isAuthenticated') === 'true';
}

/**
 * Lógica para alternar os botões de login/perfil no cabeçalho
 * consoante o estado de autenticação.
 * @returns {void}
 */
function handleAuthButtons() {
    const headerButtons = document.getElementById('header-auth-buttons');
    if (!headerButtons) return;

    headerButtons.innerHTML = ''; 

    if (isUserAuthenticated()) {
        const userName = getUserName() || 'Utilizador';
        const firstName = userName.split(' ')[0];
        const avatarUrl = localStorage.getItem('userAvatarUrl') || 'https://i.pravatar.cc/300?u=default'; 

        // ESTADO LOGADO: Avatar/Nome, Favoritos, Carrinho
        headerButtons.innerHTML = `
            <a href="perfil.html" class="user-info-link nav-icon-link" aria-label="Aceder ao Perfil">
                <img src="${avatarUrl}" alt="Avatar de ${firstName}" class="user-avatar">
                <span>Olá, ${firstName}</span>
            </a>
            <a href="favoritos.html" class="nav-icon-link" aria-label="Aceder aos Favoritos">
                <i class="fas fa-star"></i>
                <span>Favoritos</span>
            </a>
            <a href="carrinho.html" class="nav-icon-link cart-link" aria-label="Aceder ao Carrinho">
                <i class="fas fa-shopping-cart"></i>
                <span>Carrinho</span>
            </a>
        `;
    } else {
        // ESTADO DESLOGADO: Login/Registo, Carrinho
        headerButtons.innerHTML = `
            <a href="login.html" class="nav-icon-link" aria-label="Entrar ou Registar">
                <i class="fas fa-sign-in-alt"></i>
                <span>Entrar / Registo</span>
            </a>
            <a href="carrinho.html" class="nav-icon-link cart-link" aria-label="Aceder ao Carrinho">
                <i class="fas fa-shopping-cart"></i>
                <span>Carrinho</span>
            </a>
        `;
    }
}

/**
 * Aplica restrições de acesso a páginas protegidas.
 * Se o utilizador não estiver autenticado, é redirecionado para `login.html`.
 * @returns {boolean} `true` se o redirecionamento ocorreu, `false` caso contrário.
 */
function checkAccessRestriction() {
    const protectedPages = ['perfil.html', 'favoritos.html'];
    const currentPage = window.location.pathname.split('/').pop();

    if (protectedPages.includes(currentPage) && !isUserAuthenticated()) {
        alert('É necessário iniciar sessão para aceder a esta página.');
        window.location.href = 'login.html';
        return true; 
    }
    return false;
}

/**
 * Lógica que gerencia as interações de produtos ('Favoritos' e 'Comprar').
 * Se deslogado, bloqueia 'Favoritos' e redireciona para login.
 * @returns {void}
 */
function setupProtectedInteractions() {
    const isAuth = isUserAuthenticated();
    
    if (isAuth) {
         setupProductInteractions();
    } else {
        // Bloqueio para utilizadores deslogados
        document.querySelectorAll('.icone-favoritos, .comprar-btn').forEach(button => {
            
            const newListener = (event) => {
                event.preventDefault(); 
                event.stopPropagation();
                
                if (button.classList.contains('icone-favoritos')) {
                    alert('Inicie sessão para adicionar produtos aos favoritos. 🚫');
                    window.location.href = 'login.html';
                } else {
                     // Permite a adição ao carrinho (carrinho é público)
                     const productName = button.closest('.produto-card').querySelector('.produto-titulo-preco span:first-child').textContent.trim();
                     alert(`"${productName}" adicionado ao Carrinho! 🛒`);
                }
            };

            // Remove o listener anterior e adiciona o novo (para evitar duplicação em caso de recarga)
            button.removeEventListener('click', button.__protectedListener);
            button.addEventListener('click', newListener);
            button.__protectedListener = newListener; // Guarda a referência
        });
    }
}

/* ================================================= */
/* === FUNÇÕES PÁGINA LOGIN/REGISTO (LOGIN.HTML) === */
/* ================================================= */

/**
 * Exibe ou oculta uma mensagem de erro abaixo de um campo de input.
 * @param {HTMLElement} inputElement - O elemento <input> a ser validado.
 * @param {string} message - A mensagem de erro a ser exibida (string vazia para limpar).
 * @returns {void}
 */
function displayError(inputElement, message) {
    const formGroup = inputElement.closest('.form-group');
    if (!formGroup) return;
    
    let errorSpan = formGroup.querySelector('.error-message');
    
    if (!errorSpan) {
        errorSpan = document.createElement('span');
        errorSpan.classList.add('error-message');
        // Insere a span de erro após o input
        inputElement.after(errorSpan); 
    }

    if (message) {
        inputElement.classList.add('error');
        errorSpan.textContent = message;
    } else {
        inputElement.classList.remove('error');
        errorSpan.textContent = '';
    }
}

/**
 * Função auxiliar para limpar mensagens de erro num formulário.
 * @param {HTMLFormElement} form - O formulário a ser limpo.
 * @returns {void}
 */
const resetErrors = (form) => {
    form.querySelectorAll('input').forEach(input => {
        displayError(input, '');
    });
};

/**
 * Alterna a visibilidade entre os formulários de Login e Registo e atualiza os botões de alternância.
 * @param {'login'|'register'} formToShow - O nome do formulário a ser exibido.
 * @returns {void}
 */
function toggleForms(formToShow) {
    const loginForm = document.getElementById('login-form-area');
    const registerForm = document.getElementById('register-form-area');
    const switchLogin = document.getElementById('switch-login');
    const switchRegister = document.getElementById('switch-register');

    if (!loginForm || !registerForm || !switchLogin || !switchRegister) return;

    const isRegister = formToShow === 'register';

    loginForm.classList.toggle('hidden', isRegister);
    registerForm.classList.toggle('hidden', !isRegister);
    switchLogin.classList.toggle('active', !isRegister);
    switchRegister.classList.toggle('active', isRegister);
    
    resetErrors(isRegister ? registerForm : loginForm);
}

/**
 * Lógica de manipulação e validação para os formulários de Login e Registo.
 * @returns {void}
 */
function setupAuthFormInteractions() {
    const loginForm = document.getElementById('login-form-area');
    const registerForm = document.getElementById('register-form-area');

    if (!loginForm || !registerForm) return;
    
    // Configurar a alternância
    document.getElementById('switch-login').addEventListener('click', () => toggleForms('login'));
    document.getElementById('switch-register').addEventListener('click', () => toggleForms('register'));

    // 1. Submissão do Login
    loginForm.addEventListener('submit', (event) => {
        event.preventDefault();
        resetErrors(loginForm); 
        
        const emailInput = document.getElementById('login-email');
        const passwordInput = document.getElementById('login-password');
        const email = emailInput.value.trim();
        const password = passwordInput.value;
        let valid = true;

        if (!email || !email.includes('@')) {
            displayError(emailInput, 'Por favor, insira um endereço de email válido.');
            valid = false;
        }

        if (password.length < 6) {
            displayError(passwordInput, 'A password deve ter pelo menos 6 caracteres.');
            valid = false;
        }

        if (valid) {
            // Simulação de login: sucesso
            const userName = email.split('@')[0].replace(/[^a-zA-Z0-9]/g, '');
            const formattedUserName = userName.charAt(0).toUpperCase() + userName.slice(1);
            setAuthStatus(true, formattedUserName);
            alert(`Login bem-sucedido! Olá, ${formattedUserName}. Redirecionando... 🔑`);
            window.location.href = 'perfil.html'; 
        }
    });

    // 2. Submissão do Registo
    registerForm.addEventListener('submit', (event) => {
        event.preventDefault();
        resetErrors(registerForm); 
        
        const nameInput = document.getElementById('register-name');
        const emailInput = document.getElementById('register-email');
        const passwordInput = document.getElementById('register-password');
        const confirmPasswordInput = document.getElementById('register-confirm-password');
        
        const name = nameInput.value.trim();
        const email = emailInput.value.trim();
        const password = passwordInput.value;
        const confirmPassword = confirmPasswordInput.value;
        
        let valid = true;

        if (name.length < 2) {
            displayError(nameInput, 'O nome deve ter pelo menos 2 caracteres.');
            valid = false;
        }

        if (!email || !email.includes('@')) {
            displayError(emailInput, 'Por favor, insira um endereço de email válido.');
            valid = false;
        }

        if (password.length < 6) {
            displayError(passwordInput, 'A password deve ter pelo menos 6 caracteres.');
            valid = false;
        }

        if (password !== confirmPassword) {
            displayError(confirmPasswordInput, 'As passwords não coincidem.');
            valid = false;
        }

        if (valid) {
            // Simulação de Registo: sucesso
            setAuthStatus(true, name);
            alert(`Registo bem-sucedido! Sessão iniciada. Olá, ${name}. 🚀`);
            window.location.href = 'perfil.html'; 
        }
    });
}

/**
 * Lógica para o botão de Sair (Logout) no Perfil.
 * @returns {void}
 */
function setupLogout() {
    const logoutLink = document.querySelector('.logout-link');
    if (!logoutLink) return;

    logoutLink.addEventListener('click', (event) => {
        event.preventDefault();
        if (confirm('Tem a certeza que deseja sair da sua conta?')) {
            setAuthStatus(false); 
            alert('Sessão encerrada com sucesso! 👋');
            window.location.href = 'index.html';
        }
    });
}


/* ================================================= */
/* === FUNÇÕES COMUNS / GERAIS === */
/* ================================================= */

/**
 * Lida com a submissão do formulário da Newsletter no rodapé. (Simulação)
 * @returns {void}
 */
function setupFooterForm() {
    const form = document.querySelector('.newsletter-form');
    if (!form) return;

    form.addEventListener('submit', (event) => {
        event.preventDefault();
        const emailInput = form.querySelector('input[type="email"]').value;
        alert(`Obrigado por subscrever a newsletter com o e-mail: ${emailInput}! 😻`);
        form.reset();
    });
}


/* ================================================= */
/* === FUNÇÕES PÁGINA INICIAL (INDEX.HTML) === */
/* ================================================= */

/**
 * Lógica para os botões "Favoritos" (toggle) e "Comprar" (simulação de adição ao carrinho).
 * Esta função só deve ser chamada para utilizadores AUTENTICADOS.
 * @returns {void}
 */
function setupProductInteractions() {
    // A. Ícone de Favoritos
    document.querySelectorAll('.icone-favoritos').forEach(button => {
        // Garantir que listeners de bloqueio são removidos
        button.removeEventListener('click', button.__protectedListener); 
        
        button.addEventListener('click', () => {
            const card = button.closest('.produto-card');
            const productName = card ? card.querySelector('.produto-titulo-preco span:first-child').textContent.trim() : 'Produto Desconhecido';
            
            const isFavorite = button.classList.toggle('is-favorite');
            
            // Atualiza a cor (usando estilo inline para simulação)
            button.style.color = isFavorite ? 'var(--color-favorite)' : 'var(--color-text-muted)'; 
            
            alert(`"${productName}" ${isFavorite ? 'adicionado' : 'removido'} dos seus Favoritos! ${isFavorite ? '💛' : ''}`); 
        });
        
        // Configuração inicial (garante a cor inicial correta)
        if (!button.classList.contains('is-favorite')) {
            button.style.color = 'var(--color-text-muted)';
        }
    });

    // B. Botão Comprar
    document.querySelectorAll('.comprar-btn').forEach(button => {
        // Garantir que listeners de bloqueio são removidos
        button.removeEventListener('click', button.__protectedListener); 
        
        button.addEventListener('click', () => {
            const card = button.closest('.produto-card');
            const productName = card ? card.querySelector('.produto-titulo-preco span:first-child').textContent.trim() : 'Produto Desconhecido';
            alert(`"${productName}" adicionado ao Carrinho! 🛒`);
        });
    });
}

/**
 * Lógica de simulação para os links "Ver Mais" das secções de produto.
 * @returns {void}
 */
function setupVerMaisLinks() {
    document.querySelectorAll('.seccao-header .ver-mais').forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault(); 
            
            const sectionHeader = link.closest('.seccao-header');
            const sectionNameElement = sectionHeader ? sectionHeader.querySelector('h2') : null;
            const sectionName = sectionNameElement 
                ? sectionNameElement.textContent.trim()
                : 'Esta Secção';
            
            alert(`Simulação de navegação. Aqui seriam listados todos os produtos da secção: ${sectionName}.`);
        });
    });
}

/**
 * Lógica de simulação para a pesquisa na barra de pesquisa.
 * @returns {void}
 */
function setupSearchBarSimulation() {
    const searchForm = document.querySelector('.search-bar');
    const searchInput = document.getElementById('search-input');

    if (!searchForm || !searchInput) return;

    searchForm.addEventListener('submit', (event) => {
        event.preventDefault();

        const query = searchInput.value.trim();

        if (query) {
            alert(`Simulação de Pesquisa: Resultados para: "${query}".`);
        } else {
            alert('Simulação de Pesquisa: Por favor, insira um termo para pesquisar.');
        }
        
        searchInput.value = '';
        searchInput.blur(); 
    });
}


/**
 * Lógica para a Navegação de Categorias (Scroll Suave e Estado Ativo).
 * Utiliza `scrollIntoView()` em conjunto com o CSS `scroll-margin-top` para compensar o cabeçalho fixo.
 * @returns {void}
 */
function setupCategoryNavigation() {
    document.querySelectorAll('.categorias-nav .nav-item').forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault();
            
            const targetId = link.getAttribute('href').substring(1); 
            const targetElement = document.getElementById(targetId);
            
            // 1. Atualizar classe 'active'
            document.querySelectorAll('.categorias-nav .nav-item').forEach(l => l.classList.remove('active'));
            link.classList.add('active');

            // 2. Scroll Suave para a secção
            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: "smooth",
                    block: "start"
                });
            }
        });
    });
}

/**
 * Lógica para inicializar e controlar o carrossel de produtos numa dada secção.
 * @param {string} sectionId - O ID da secção que contém o carrossel (ex: 'alimentacao').
 * @returns {void}
 */
function setupCarousel(sectionId) {
    const section = document.getElementById(sectionId);
    if (!section) return;

    const list = section.querySelector('.lista-produtos');
    const prevBtn = section.querySelector('.seta-prev');
    const nextBtn = section.querySelector('.seta-next');
    const bulletsContainer = section.querySelector('.bullets-container');
    const productCards = list.querySelectorAll('.produto-card');

    if (productCards.length === 0 || !list) {
        // Oculta os controlos se não houver produtos ou seletor inválido
        if (prevBtn) prevBtn.style.display = 'none';
        if (nextBtn) nextBtn.style.display = 'none';
        if (bulletsContainer) bulletsContainer.style.display = 'none';
        return;
    }
    
    /**
     * Cria e configura os bullets de navegação do carrossel.
     */
    const setupBullets = () => {
        bulletsContainer.innerHTML = '';
        const listClientWidth = list.clientWidth;
        // Scroll máximo que pode ocorrer
        const maxScroll = list.scrollWidth - listClientWidth;
        // Número de "páginas" (slides completos)
        const numPages = Math.ceil(maxScroll / listClientWidth) + 1; 

        for (let i = 0; i < numPages; i++) {
            const bullet = document.createElement('span');
            bullet.classList.add('bullet');
            bullet.dataset.page = i;
            bulletsContainer.appendChild(bullet);

            bullet.addEventListener('click', () => {
                const targetScroll = i * listClientWidth;
                list.scrollTo({ left: targetScroll, behavior: 'smooth' });
            });
        }
    };

    /**
     * Atualiza o estado dos botões de navegação e dos bullets ativos.
     */
    const updateState = () => {
        const scrollLeft = list.scrollLeft;
        const bullets = bulletsContainer.querySelectorAll('.bullet');
        if (bullets.length === 0) return;

        const maxScroll = list.scrollWidth - list.clientWidth;
        const listClientWidth = list.clientWidth;
        const SCROLL_TOLERANCE = 5; 
        
        let activePageIndex = Math.round(scrollLeft / listClientWidth);
        
        // Ajuste para garantir que o último bullet é ativado quando o scroll atinge o fim
        if (scrollLeft >= (maxScroll - SCROLL_TOLERANCE)) {
             activePageIndex = bullets.length - 1;
        }

        bullets.forEach((bullet, index) => {
            bullet.classList.toggle('active', index === activePageIndex);
        });

        // Atualiza o estado dos botões de setas (prev/next)
        const isStart = scrollLeft === 0;
        const isEnd = (scrollLeft >= (maxScroll - SCROLL_TOLERANCE));
        
        prevBtn.disabled = isStart;
        nextBtn.disabled = isEnd;
        prevBtn.style.opacity = isStart ? '0.5' : '1';
        nextBtn.style.opacity = isEnd ? '0.5' : '1';
    };

    // Listeners de Setas
    nextBtn.addEventListener('click', () => {
        list.scrollBy({ left: list.clientWidth, behavior: 'smooth' });
    });

    prevBtn.addEventListener('click', () => {
        list.scrollBy({ left: -list.clientWidth, behavior: 'smooth' });
    });

    // Listener de Scroll e Resize
    list.addEventListener('scroll', updateState);

    window.addEventListener('resize', () => {
        // É necessário recalcular os bullets e o estado no resize
        setupBullets(); 
        updateState();
    });

    // Inicialização
    setupBullets();
    updateState();
}


/* ================================================= */
/* === FUNÇÕES PÁGINA CARRINHO (CARRINHO.HTML) === */
/* ================================================= */

/**
 * Função utilitária para formatar um valor numérico para a moeda EUR.
 * @param {number} value - O valor a ser formatado.
 * @returns {string} O valor formatado (ex: "23,00 €").
 */
const formatCurrency = (value) => {
    return value.toLocaleString('pt-PT', { style: 'currency', currency: 'EUR' });
};

/**
 * Calcula e atualiza o subtotal e total no resumo do carrinho.
 * Lida também com o estado de carrinho vazio.
 * @returns {void}
 */
function updateCartSummary() {
    const listContainer = document.querySelector('.lista-itens');
    const resumoContainer = document.querySelector('.resumo-carrinho');
    const emptyMessage = document.querySelector('.lista-vazia-texto');

    if (!listContainer || !resumoContainer || !emptyMessage) return;

    const items = listContainer.querySelectorAll('.carrinho-item');
    let subtotal = 0;
    const shippingCost = 4.00; // Custo fixo de envio

    items.forEach(item => {
        const priceText = item.querySelector('.item-preco').textContent;
        // Converte a string de preço portuguesa ("3,00€") para float (3.00)
        const price = parseFloat(priceText.replace('€', '').replace(',', '.'));
        
        const quantityInput = item.querySelector('.item-quantidade input');
        const quantity = parseInt(quantityInput.value);
        
        if (!isNaN(price) && !isNaN(quantity)) {
            subtotal += price * quantity;
        }
    });

    const total = subtotal + shippingCost;
    
    // Atualiza os valores
    const subtotalElement = resumoContainer.querySelector('.carrinho-detalhe:nth-child(2) span:last-child');
    if (subtotalElement) subtotalElement.textContent = formatCurrency(subtotal);

    const totalElement = resumoContainer.querySelector('.carrinho-total span:last-child');
    if (totalElement) totalElement.textContent = formatCurrency(total);
    
    // Atualiza o título (contagem de itens)
    const totalItems = items.length;
    const heading = document.querySelector('.carrinho-layout h1');
    if (heading) heading.textContent = `O Seu Carrinho (${totalItems} Iten${totalItems === 1 ? '' : 's'})`;

    // Mostra/Esconde secções com base no estado de carrinho vazio
    const isCartEmpty = totalItems === 0;
    listContainer.style.display = isCartEmpty ? 'none' : 'block';
    resumoContainer.style.display = isCartEmpty ? 'none' : 'block';
    emptyMessage.style.display = isCartEmpty ? 'block' : 'none';
}


/**
 * Inicializa a lógica de interações do carrinho: remoção, atualização de quantidade e finalização de compra.
 * @returns {void}
 */
function setupCartInteractions() {
    const listContainer = document.querySelector('.lista-itens');
    const resumoContainer = document.querySelector('.resumo-carrinho');
    
    if (!listContainer || !resumoContainer) return;

    // 1. Botão Remover Item
    listContainer.addEventListener('click', (event) => {
        if (event.target.classList.contains('remover-item')) {
            const item = event.target.closest('.carrinho-item');
            const itemName = item.querySelector('h3').textContent;
            
            if (confirm(`Tem a certeza que quer remover "${itemName}" do carrinho?`)) {
                item.remove();
                updateCartSummary();
            }
        }
    });

    // 2. Alteração de Quantidade
    listContainer.addEventListener('change', (event) => {
        const quantityInput = event.target.closest('.item-quantidade input');
        if (quantityInput) {
            // Garante que a quantidade é pelo menos 1 e é um número inteiro
            let quantity = parseInt(quantityInput.value);
            if (quantity < 1 || isNaN(quantity)) {
                quantity = 1;
                quantityInput.value = 1;
            }
            updateCartSummary();
        }
    });

    // 3. Botão Finalizar Compra
    const finalizeBtn = resumoContainer.querySelector('.btn-finalizar');
    if (finalizeBtn) {
        finalizeBtn.addEventListener('click', () => {
            alert('A avançar para o Checkout! 🚀 (Simulação de finalização de compra)');
        });
    }

    // Chamada inicial para preencher os totais e verificar o estado
    updateCartSummary();
}


/* ================================================= */
/* === FUNÇÕES PÁGINA PERFIL (PERFIL.HTML) === */
/* ================================================= */

/**
 * Função auxiliar para re-adicionar listeners aos links de edição na secção de detalhes.
 * @returns {void}
 */
const setupEditLinks = () => {
    document.querySelectorAll('.edit-link').forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault();
            alert(`Simulação: O formulário de edição para "${link.textContent.trim()}" iria abrir aqui. 📝`);
        });
    });
};

/**
 * Lógica para a navegação do menu lateral do perfil e carregamento de conteúdo simulado.
 * @returns {void}
 */
function setupProfileInteractions() {
    const menuLinks = document.querySelectorAll('.menu-perfil nav ul li a:not(.logout-link)');
    const detailsSection = document.querySelector('.detalhes-perfil');
    
    if (!detailsSection) return;

    // Armazena o HTML original da secção de Detalhes da Conta (primeira secção)
    const originalDetailsHTML = detailsSection.innerHTML;

    // 1. Navegação do Menu do Perfil
    menuLinks.forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault();

            // Atualiza a classe ativa
            menuLinks.forEach(l => l.classList.remove('active'));
            link.classList.add('active');

            const sectionName = link.textContent.trim();

            if (sectionName === 'Detalhes da Conta') {
                // Restaura o conteúdo original da conta
                detailsSection.innerHTML = originalDetailsHTML;
                setupEditLinks(); // Re-adicionar listeners aos botões de edição
            } else {
                // Conteúdo simulado para outras secções
                detailsSection.innerHTML = `
                    <h1>${sectionName}</h1>
                    <p>Esta é a vista simulada para a secção de <strong>${sectionName}</strong>.</p>
                    <p>Num website real, o conteúdo seria carregado dinamicamente.</p>
                `;
            }
        });
    });

    // 2. Links de Edição (Inicialização)
    setupEditLinks(); 
}
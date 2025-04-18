document.addEventListener('DOMContentLoaded', function() {
    // Toggle para mostrar/esconder senha
    const togglePassword = document.querySelector('.toggle-password');
    const password = document.querySelector('#password');
    
    togglePassword.addEventListener('click', function() {
        const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
        password.setAttribute('type', type);
        
        // Troca o ícone
        this.querySelector('i').classList.toggle('fa-eye');
        this.querySelector('i').classList.toggle('fa-eye-slash');
    });
    
    // Cancelar button
    const cancelBtn = document.querySelector('#cancelBtn');
    cancelBtn.addEventListener('click', function() {
        document.querySelector('#username').value = '';
        document.querySelector('#password').value = '';
        document.querySelector('#remember').checked = false;
    });
    
    // Validação de senha
if(password.value !== confirmPassword.value) {
    alert('As senhas não coincidem!');
    return;
}

// ========== RECUPERAÇÃO DE SENHA ==========
const recoveryForm = document.querySelector('#recoveryForm');

if (recoveryForm) {
    recoveryForm.addEventListener('submit', function(e) {
        e.preventDefault();
        
        const recoveryEmail = document.querySelector('#recoveryEmail').value;
        
        // Simulação de envio
        if(recoveryEmail) {
            alert('Código de recuperação enviado para o email de recuperação');
            // Redirecionamento ou lógica adicional aqui
        }
    });
}

    // Form submission
    const loginForm = document.querySelector('#loginForm');
    loginForm.addEventListener('submit', function(e) {
        e.preventDefault();
        
        const username = document.querySelector('#username').value;
        const password = document.querySelector('#password').value;
        const remember = document.querySelector('#remember').checked;
        
        // Aqui você pode adicionar a lógica de autenticação
        console.log('Tentativa de login:', { username, password, remember });
        
        // Simulação de login (substitua por sua lógica real)
        if(username && password) {
            alert('Login realizado com sucesso! Redirecionando...');
            // window.location.href = 'dashboard.html'; // Redirecionar após login
        } else {
            alert('Por favor, preencha todos os campos!');
        }
    });
});

<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Monster - Login </title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body { background-color: #f4f6f9; height: 100vh; display: flex; align-items: center; justify-content: center; }
        .card-login { width: 400px; border: none; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); }
    </style>
</head>
<body>

<div class="card card-login p-4">
    <div class="text-center mb-4">
        <h4 class="fw-bold text-primary">Iniciar Sesión (JSP)</h4>
    </div>
    
    <div id="alertBox" class="alert d-none" role="alert"></div>

    <form id="loginForm">
        <div class="mb-3">
            <label class="form-label fw-semibold">Código de Empleado (Ej: EMP00001)</label>
            <input type="text" class="form-control" id="codigo" required>
        </div>
        <div class="mb-3">
            <label class="form-label fw-semibold">Contraseña</label>
            <input type="password" class="form-control" id="password" required>
        </div>
        <button type="submit" class="btn btn-primary w-100 py-2 fw-bold" id="btnIngresar">Ingresar al Sistema</button>
    </form>
</div>

<script>
    let countdownInterval = null;

    document.getElementById('loginForm').addEventListener('submit', async (e) => {
        e.preventDefault();
        
        const codigo = document.getElementById('codigo').value;
        const password = document.getElementById('password').value;
        const alertBox = document.getElementById('alertBox');
        const btnIngresar = document.getElementById('btnIngresar');

        try {
            const response = await fetch('${pageContext.request.contextPath}/api/seguridad/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ codigo, password })
            });

            const mensaje = await response.text();

            if (response.ok) {
                alertBox.className = "alert alert-success";
                alertBox.textContent = mensaje;
                alertBox.classList.remove('d-none');
                setTimeout(() => {
                    window.location.href = '${pageContext.request.contextPath}/menu';
                }, 1500);
            } else if (response.status === 429) {
                alertBox.className = "alert alert-warning";
                alertBox.textContent = mensaje;
                alertBox.classList.remove('d-none');
                iniciarCountdown(alertBox, mensaje);
            } else {
                alertBox.className = "alert alert-danger";
                alertBox.textContent = mensaje;
                alertBox.classList.remove('d-none');
            }
        } catch (error) {
            alertBox.className = "alert alert-danger";
            alertBox.textContent = "Error al intentar autenticar con el servidor.";
            alertBox.classList.remove('d-none');
        }
    });

    function iniciarCountdown(alertBox, mensaje) {
        if (countdownInterval) clearInterval(countdownInterval);
        const btnIngresar = document.getElementById('btnIngresar');
        btnIngresar.disabled = true;

        const segundosMatch = mensaje.match(/(\d+)\s*segundos/);
        let segundos = segundosMatch ? parseInt(segundosMatch[1]) : 60;

        countdownInterval = setInterval(() => {
            segundos--;
            if (segundos <= 0) {
                clearInterval(countdownInterval);
                countdownInterval = null;
                alertBox.className = "alert d-none";
                alertBox.textContent = "";
                btnIngresar.disabled = false;
            } else {
                alertBox.textContent = "Demasiados intentos fallidos. Intente de nuevo en " + segundos + " segundos.";
            }
        }, 1000);
    }
</script>

</body>
</html>
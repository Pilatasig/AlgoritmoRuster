<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Monster - Login JSP</title>
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
        <button type="submit" class="btn btn-primary w-100 py-2 fw-bold">Ingresar al Sistema</button>
    </form>
        <div class="text-center mt-3">
            <a href="${pageContext.request.contextPath}/registro" class="text-decoration-none small">¿No tienes usuario? Regístrate aquí</a>
        </div>
</div>

<script>
    document.getElementById('loginForm').addEventListener('submit', async (e) => {
        e.preventDefault();
        
        const codigo = document.getElementById('codigo').value;
        const password = document.getElementById('password').value;
        const alertBox = document.getElementById('alertBox');

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
</script>

</body>
</html>
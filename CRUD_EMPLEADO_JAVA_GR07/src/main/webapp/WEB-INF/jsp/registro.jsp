<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Monster - Registro JSP</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body { background-color: #f4f6f9; height: 100vh; display: flex; align-items: center; justify-content: center; }
        .card-register { width: 400px; border: none; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); }
    </style>
</head>
<body>

<div class="card card-register p-4">
    <div class="text-center mb-4">
        <h4 class="fw-bold text-success">Registrar Acceso (JSP)</h4>
        <p class="text-muted small">El código se generará automáticamente en la BD</p>
    </div>
    
    <div id="alertBox" class="alert d-none" role="alert"></div>

    <form id="registerForm">
        <div class="mb-3">
            <label class="form-label fw-semibold">Nombre del Funcionario</label>
            <input type="text" class="form-control" id="nombres" required>
        </div>
        <div class="mb-3">
            <label class="form-label fw-semibold">Contraseña</label>
            <input type="password" class="form-control" id="password" required>
        </div>
        <button type="submit" class="btn btn-success w-100 py-2 fw-bold">Generar Cuenta</button>
    </form>
    
    <div class="text-center mt-3">
        <a href="${pageContext.request.contextPath}/login" class="text-decoration-none small">Ir al Inicio de Sesión</a>
    </div>
</div>

<script>
    document.getElementById('registerForm').addEventListener('submit', async (e) => {
        e.preventDefault();
        
        const nombres = document.getElementById('nombres').value;
        const password = document.getElementById('password').value;
        const alertBox = document.getElementById('alertBox');

        try {
            // Llama a tu endpoint REST de seguridad
            const response = await fetch('${pageContext.request.contextPath}/api/seguridad/registro', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ nombres, password })
            });

            const mensaje = await response.text();

            if (response.ok) {
                alertBox.className = "alert alert-success";
                alertBox.innerHTML = `<strong>¡Éxito!</strong><br>\${mensaje}<br><br><span class='small text-dark'>Anota tu código. Redirigiendo...</span>`;
                alertBox.classList.remove('d-none');
                setTimeout(() => { window.location.href = '${pageContext.request.contextPath}/login'; }, 5000);
            } else {
                alertBox.className = "alert alert-danger";
                alertBox.textContent = mensaje;
                alertBox.classList.remove('d-none');
            }
        } catch (error) {
            alertBox.className = "alert alert-danger";
            alertBox.textContent = "Error al conectar con el servidor central.";
            alertBox.classList.remove('d-none');
        }
    });
</script>

</body>
</html>

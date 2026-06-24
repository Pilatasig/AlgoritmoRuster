<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - En Construcción</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="${pageContext.request.contextPath}/css/global-layout.css" rel="stylesheet">
</head>
<body>
<div class="container-fluid p-0">
    <div class="row g-0">
        <jsp:include page="sidebar.jsp"/>
        <div class="col-12 col-md-9 col-lg-10 main-content">
            <div class="d-flex justify-content-center align-items-center" style="min-height: 70vh;">
                <div class="text-center">
                    <div class="display-1 text-muted mb-4">
                        <i class="bi bi-tools"></i>
                    </div>
                    <h1 class="fw-bold text-dark">Página en Construcción</h1>
                    <p class="text-muted fs-5">Este módulo se encuentra actualmente en desarrollo.</p>
                    <p class="text-muted">Pronto estará disponible para su uso.</p>
                    <a href="${pageContext.request.contextPath}/menu" class="btn btn-primary fw-bold mt-3">
                        <i class="bi bi-house-fill me-1"></i>Volver al Inicio
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

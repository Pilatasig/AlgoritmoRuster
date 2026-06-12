<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - Panel de Control</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="${pageContext.request.contextPath}/css/global-layout.css" rel="stylesheet">
</head>
<body>

<div class="container-fluid p-0">
    <div class="row g-0">
        
        <jsp:include page="sidebar.jsp"/>

        <div class="col-12 col-md-9 col-lg-10 main-content">
            
            <div class="bg-white p-4 rounded-3 shadow-sm mb-4">
                <h1 class="h2 fw-bold text-dark m-0">Bienvenido al Sistema de Gestión</h1>
                <p class="text-muted m-0 mt-1">Seleccione una opción del menú lateral izquierdo para administrar los registros.</p>
            </div>

            <div class="row g-4">
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Estructura Física</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Departamentos</h3>
                            </div>
                            <div class="bg-primary-subtle text-primary p-3 rounded-3 fw-bold fs-4">
                                D
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/departamentos" class="text-primary small fw-semibold text-decoration-none">Gestionar catálogo &rarr;</a>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Perfiles Laborales</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Cargos</h3>
                            </div>
                            <div class="bg-success-subtle text-success p-3 rounded-3 fw-bold fs-4">
                                C
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/cargos" class="text-success small fw-semibold text-decoration-none">Configurar plazas &rarr;</a>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Talento Humano</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Empleados</h3>
                            </div>
                            <div class="bg-warning-subtle text-warning p-3 rounded-3 fw-bold fs-4">
                                E
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/empleados" class="text-warning small fw-semibold text-decoration-none">Gestionar nómina &rarr;</a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card border-0 shadow-sm p-4 mt-4 bg-white">
                <h5 class="fw-bold text-secondary mb-2">Auditoría y Cambios de Personal</h5>
                <p class="text-muted m-0 small">
                    Recuerde que los cargos se encuentran atados rígidamente a sus departamentos de origen. Cualquier transferencia o historial de movimientos de un empleado se registrará de forma automática mediante la bitácora de la tabla intermedia de cambios de personal.
                </p>
            </div>

        </div>
        
    </div>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
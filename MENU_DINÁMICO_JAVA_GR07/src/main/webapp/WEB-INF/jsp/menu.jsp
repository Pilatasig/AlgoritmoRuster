<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.Set" %>
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

<%
    Set<String> menus = (Set<String>) session.getAttribute("menusPermitidos");
    boolean tieneMenu = menus != null;
%>

<div class="container-fluid p-0">
    <div class="row g-0">
        
        <jsp:include page="sidebar.jsp"/>

        <div class="col-12 col-md-9 col-lg-10 main-content">
            
            <div class="bg-white p-4 rounded-3 shadow-sm mb-4">
                <h1 class="h2 fw-bold text-dark m-0">Bienvenido al Sistema de Gestión</h1>
                <p class="text-muted m-0 mt-1">Seleccione una opción del menú lateral izquierdo para administrar los registros.</p>
            </div>

            <div class="row g-4">
                <% if (tieneMenu && menus.contains("P01")) { %>
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
                <% } %>

                <% if (tieneMenu && menus.contains("P02")) { %>
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
                <% } %>

                <% if (tieneMenu && menus.contains("P03")) { %>
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
                <% } %>

                <% if (tieneMenu && menus.contains("X01")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Seguridad</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Perfiles</h3>
                            </div>
                            <div class="bg-info-subtle text-info p-3 rounded-3 fw-bold fs-4">
                                P
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/perfiles" class="text-info small fw-semibold text-decoration-none">Administrar roles &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("X02")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Seguridad</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Asignar Perfiles</h3>
                            </div>
                            <div class="bg-secondary-subtle text-secondary p-3 rounded-3 fw-bold fs-4">
                                AP
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/asignar-perfiles" class="text-secondary small fw-semibold text-decoration-none">Vincular usuarios a roles &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("X03")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Seguridad</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Opciones por Perfil</h3>
                            </div>
                            <div class="bg-dark-subtle text-dark p-3 rounded-3 fw-bold fs-4">
                                OP
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/opciones-perfil" class="text-dark small fw-semibold text-decoration-none">Gestionar opciones por rol &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("X04")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Seguridad</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Usuarios</h3>
                            </div>
                            <div class="bg-dark-subtle text-dark p-3 rounded-3 fw-bold fs-4">
                                U
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/usuarios" class="text-dark small fw-semibold text-decoration-none">Gestionar usuarios del sistema &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("F01")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Finanzas</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Facturación</h3>
                            </div>
                            <div class="p-3 rounded-3 fw-bold fs-4" style="background-color:#e2d5f2;color:#6f42c1;">
                                F01
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/facturacion" class="text-purple small fw-semibold text-decoration-none" style="color:#6f42c1;">Gestionar facturación &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("F02")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Finanzas</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Presupuestos</h3>
                            </div>
                            <div class="p-3 rounded-3 fw-bold fs-4" style="background-color:#fae3f0;color:#e83e8c;">
                                F02
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/presupuestos" class="text-pink small fw-semibold text-decoration-none" style="color:#e83e8c;">Gestionar presupuestos &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("F03")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Finanzas</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Reportes Financieros</h3>
                            </div>
                            <div class="p-3 rounded-3 fw-bold fs-4" style="background-color:#d6f0f7;color:#17a2b8;">
                                F03
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/reportes-financieros" class="text-cyan small fw-semibold text-decoration-none" style="color:#17a2b8;">Consultar reportes financieros &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("G01")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Gestión de Proyectos</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Proyectos</h3>
                            </div>
                            <div class="p-3 rounded-3 fw-bold fs-4" style="background-color:#d4edda;color:#28a745;">
                                G01
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/proyectos" class="text-green small fw-semibold text-decoration-none" style="color:#28a745;">Gestionar proyectos &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("G02")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Gestión de Proyectos</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Tareas</h3>
                            </div>
                            <div class="p-3 rounded-3 fw-bold fs-4" style="background-color:#d1f0e4;color:#20c997;">
                                G02
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/tareas" class="text-teal small fw-semibold text-decoration-none" style="color:#20c997;">Gestionar tareas &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>

                <% if (tieneMenu && menus.contains("G03")) { %>
                <div class="col-12 col-sm-6 col-xl-4">
                    <div class="card stat-card bg-white shadow-sm p-4">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <h6 class="text-muted text-uppercase fw-bold small m-0">Gestión de Proyectos</h6>
                                <h3 class="fw-bold text-dark mt-2 mb-0">Asignaciones</h3>
                            </div>
                            <div class="p-3 rounded-3 fw-bold fs-4" style="background-color:#fde2cf;color:#fd7e14;">
                                G03
                            </div>
                        </div>
                        <div class="mt-3">
                            <a href="${pageContext.request.contextPath}/asignaciones" class="text-orange small fw-semibold text-decoration-none" style="color:#fd7e14;">Gestionar asignaciones &rarr;</a>
                        </div>
                    </div>
                </div>
                <% } %>
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
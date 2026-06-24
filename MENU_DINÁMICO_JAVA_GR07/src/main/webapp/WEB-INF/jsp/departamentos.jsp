<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.Set" %>
<%@ page import="java.util.stream.Collectors" %>
<%
    Set<String> permisos = (Set<String>) session.getAttribute("permisos");
    boolean puedeP11 = permisos != null && permisos.contains("P11");
    String permisosJson = permisos != null ? "[" + permisos.stream().map(p -> "\"" + p + "\"").collect(Collectors.joining(",")) + "]" : "[]";
%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - CRUD Departamentos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="${pageContext.request.contextPath}/css/global-layout.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
</head>
<body>

<div class="container-fluid p-0">
    <div class="row g-0">
        
        <jsp:include page="sidebar.jsp" />

        <div class="col-12 col-md-9 col-lg-10 main-content">
            
            <div class="d-flex justify-content-between align-items-center mb-4 bg-white p-3 rounded shadow-sm">
                <h2 class="fw-bold text-dark m-0">Gestión de Departamentos</h2>
            </div>

            <div id="alertGlobal" class="alert d-none" role="alert"></div>

            <div class="row">
                <% if (puedeP11) { %>
                <div class="col-xl-4 col-md-5 mb-4">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <h5 class="fw-bold text-primary mb-3">Nuevo Departamento</h5>
                        <form id="formDepar">

                            <div class="mb-3">
                                <label class="form-label fw-semibold">Nombre Corto / Nemónico (CHAR 3)</label>
                                <input type="text" class="form-control text-uppercase fw-bold" id="nombreDepar" maxlength="3" placeholder="Ej: INF" required>
                                <div class="form-text small text-muted">Código de 3 letras único para el departamento.</div>
                            </div>

                            <div class="mb-3">
                                <label class="form-label fw-semibold">Descripción Completa</label>
                                <input type="text" class="form-control" id="descriDepar" maxlength="50" placeholder="Ej: Departamento de Informática" required>
                            </div>

                            <button type="submit" class="btn btn-primary w-100 fw-bold py-2">
                                <i class="bi bi-save-fill me-2"></i>Guardar Departamento
                            </button>
                        </form>
                    </div>
                </div>
                <% } %>

                <div class="col-xl-8 col-md-<%= puedeP11 ? "7" : "12" %>">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <h5 class="fw-bold text-dark mb-3">Registros Existentes</h5>
                        <div class="table-responsive">
                            <table class="table table-hover align-middle">
                                <thead class="table-dark">
                                    <tr>
                                        <th style="width: 25%"><i class="bi bi-key-fill me-1"></i>Código</th>
                                        <th style="width: 20%">Nemónico</th>
                                        <th style="width: 30%">Descripción</th>
                                        <th style="width: 25%" class="text-center">Acciones</th>
                                    </tr>
                                </thead>
                                <tbody id="tablaCuerpo">
                                    </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div> </div> </div> </div> <div class="modal fade" id="modalEditar" data-bs-backdrop="static" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content border-0 shadow">
            <div class="modal-header bg-warning text-dark">
                <h5 class="modal-title fw-bold"><i class="bi bi-pencil-square me-2"></i>Modificar Departamento</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body p-4">
                <input type="hidden" id="editCodigoDepar">
                
                <div class="mb-3">
                    <label class="form-label fw-semibold">Nombre Corto / Nemónico (CHAR 3)</label>
                    <input type="text" class="form-control text-uppercase fw-bold" id="editNombreDepar" maxlength="3" required>
                </div>

                <div class="mb-3">
                    <label class="form-label fw-semibold">Nueva Descripción</label>
                    <input type="text" class="form-control" id="editDescriDepar" maxlength="50" required>
                </div>
            </div>
            <div class="modal-footer bg-light">
                <button type="button" class="btn btn-secondary fw-semibold" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btn btn-success fw-bold px-4" onclick="guardarEdicion()">
                    <i class="bi bi-check-circle-fill me-1"></i>Actualizar Cambios
                </button>
            </div>
        </div>
    </div>
</div>

<script>
    var PERMISOS = <%= permisosJson %>;
</script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script src="${pageContext.request.contextPath}/js/departamentos-crud.js"></script>
</body>
</html>
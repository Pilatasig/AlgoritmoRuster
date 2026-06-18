<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - Asignar Perfiles</title>
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
                <h2 class="fw-bold text-dark m-0">Asignaci&oacute;n de Perfiles a Usuarios</h2>
            </div>

            <div id="alertGlobal" class="alert d-none" role="alert"></div>

            <div class="card border-0 shadow-sm p-4 mb-4 bg-white">
                <div class="row align-items-end">
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Seleccionar Perfil</label>
                        <select class="form-select" id="selectPerfil">
                            <option value="">-- Seleccione un perfil --</option>
                        </select>
                    </div>
                    <div class="col-md-3">
                        <button class="btn btn-info w-100 fw-bold" onclick="cargarAsignaciones()">
                            <i class="bi bi-search"></i> Consultar
                        </button>
                    </div>
                </div>
            </div>

            <div class="row" id="panelesAsignacion" style="display:none;">
                <div class="col-md-6 mb-4">
                    <div class="card border-0 shadow-sm bg-white h-100">
                        <div class="card-header bg-success text-white fw-bold">
                            <i class="bi bi-check-circle-fill"></i> Usuarios Asignados
                            <span class="badge bg-light text-dark float-end" id="badgeAsignados">0</span>
                        </div>
                        <div class="card-body p-2">
                            <div class="table-responsive" style="max-height:400px; overflow-y:auto;">
                                <table class="table table-sm table-hover align-middle mb-0">
                                    <thead class="table-success small">
                                        <tr>
                                            <th>C&oacute;digo</th>
                                            <th>Apellidos</th>
                                            <th>Nombres</th>
                                            <th style="width:90px"></th>
                                        </tr>
                                    </thead>
                                    <tbody id="tablaAsignados"></tbody>
                                </table>
                            </div>
                            <div class="text-center text-muted small py-3" id="emptyAsignados">
                                No hay usuarios asignados a este perfil.
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 mb-4">
                    <div class="card border-0 shadow-sm bg-white h-100">
                        <div class="card-header bg-secondary text-white fw-bold">
                            <i class="bi bi-plus-circle-fill"></i> Usuarios Disponibles
                            <span class="badge bg-light text-dark float-end" id="badgeDisponibles">0</span>
                        </div>
                        <div class="card-body p-2">
                            <div class="table-responsive" style="max-height:400px; overflow-y:auto;">
                                <table class="table table-sm table-hover align-middle mb-0">
                                    <thead class="table-secondary small">
                                        <tr>
                                            <th>C&oacute;digo</th>
                                            <th>Apellidos</th>
                                            <th>Nombres</th>
                                            <th style="width:90px"></th>
                                        </tr>
                                    </thead>
                                    <tbody id="tablaDisponibles"></tbody>
                                </table>
                            </div>
                            <div class="text-center text-muted small py-3" id="emptyDisponibles">
                                Todos los usuarios tienen este perfil asignado.
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script src="${pageContext.request.contextPath}/js/asignar-perfiles.js"></script>
</body>
</html>

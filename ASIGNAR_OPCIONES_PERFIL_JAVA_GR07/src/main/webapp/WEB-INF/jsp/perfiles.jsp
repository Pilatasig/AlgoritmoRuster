<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - Módulo Perfiles</title>
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
                <h2 class="fw-bold text-dark m-0">Gesti&oacute;n de Perfiles de Usuario</h2>
            </div>

            <div id="alertGlobal" class="alert d-none" role="alert"></div>

            <div class="row">
                <div class="col-xl-4 col-md-5 mb-4">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <h5 class="fw-bold text-primary mb-3">Nuevo Perfil</h5>
                        <form id="formPerfil">

                            <div class="mb-3">
                                <label class="form-label fw-semibold">Nombre Corto / Nem&oacute;nico</label>
                                <input type="text" class="form-control text-uppercase" id="nombrePerfil" maxlength="3" placeholder="Ej: ADM" required>
                                <div class="form-text small">C&oacute;digo de 3 letras &uacute;nico para el perfil.</div>
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-semibold">Descripci&oacute;n del Perfil</label>
                                <input type="text" class="form-control" id="descripcionPerfil" maxlength="100" placeholder="Ej: Administrador del Sistema" required>
                            </div>
                            <button type="submit" class="btn btn-primary w-100 fw-bold">
                                <i class="bi bi-plus-circle-fill"></i> Registrar Perfil
                            </button>
                        </form>
                    </div>
                </div>

                <div class="col-xl-8 col-md-7">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <h5 class="fw-bold text-dark mb-3">Perfiles Registrados</h5>

                        <div class="table-responsive">
                            <table class="table table-hover align-middle">
                                <thead class="table-dark">
                                    <tr>
                                        <th style="width: 20%">C&oacute;digo</th>
                                        <th style="width: 15%">Nem&oacute;nico</th>
                                        <th style="width: 40%">Descripci&oacute;n</th>
                                        <th style="width: 25%" class="text-center">Acciones</th>
                                    </tr>
                                </thead>
                                <tbody id="tablaCuerpo">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="modalEditar" data-bs-backdrop="static" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-warning text-dark">
                <h5 class="modal-title fw-bold"><i class="bi bi-pencil-square"></i> Modificar Perfil</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">

                <input type="hidden" id="editCodigoPerfil">

                <div class="mb-3">
                    <label class="form-label fw-semibold">Nombre Corto</label>
                    <input type="text" class="form-control text-uppercase" id="editNombrePerfil" maxlength="3" required>
                </div>
                <div class="mb-3">
                    <label class="form-label fw-semibold">Nueva Descripci&oacute;n</label>
                    <input type="text" class="form-control" id="editDescripcionPerfil" maxlength="100" required>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btn btn-success fw-bold" onclick="guardarEdicion()">
                    <i class="bi bi-save2-fill"></i> Grabar Cambios
                </button>
            </div>
        </div>
    </div>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script src="${pageContext.request.contextPath}/js/perfiles-crud.js"></script>
</body>
</html>

<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - Módulo Cargos</title>
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
                <h2 class="fw-bold text-dark m-0">Gestión de Cargos Institucionales</h2>
            </div>

            <div id="alertGlobal" class="alert d-none" role="alert"></div>

            <div class="row">
                <div class="col-xl-4 col-md-5 mb-4">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <h5 class="fw-bold text-primary mb-3">Nuevo Cargo</h5>
                        <form id="formCargo">

                            <div class="mb-3">
                                <label class="form-label fw-semibold">Nombre Corto / Nemónico</label>
                                <input type="text" class="form-control text-uppercase" id="nombreCargo" maxlength="3" placeholder="Ej: GER" required>
                                <div class="form-text small">Código de 3 letras único para el cargo.</div>
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-semibold">Descripción del Cargo</label>
                                <input type="text" class="form-control" id="descripcionCargo" maxlength="255" placeholder="Ej: Gerente General" required>
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-semibold">Departamento Asignado</label>
                                <select class="form-select" id="comboDepartamento" required>
                                    <option value="" selected disabled>Seleccione un departamento...</option>
                                </select>
                            </div>
                            <button type="submit" class="btn btn-primary w-100 fw-bold">
                                <i class="bi bi-plus-circle-fill"></i> Registrar Cargo
                            </button>
                        </form>
                    </div>
                </div>

                <div class="col-xl-8 col-md-7">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <div class="d-flex flex-column flex-sm-row justify-content-between align-items-sm-center mb-3 gap-2">
                            <h5 class="fw-bold text-dark m-0">Cargos Registrados</h5>
                            <div class="d-flex align-items-center gap-2" style="min-width: 280px;">
                                <label class="text-muted small fw-bold text-nowrap m-0">Filtrar por:</label>
                                <select class="form-select form-select-sm" id="filtroDepartamento">
                                    <option value="TODOS">-- Todos los Departamentos --</option>
                                </select>
                            </div>
                        </div>
                        
                        <div class="table-responsive">
                            <table class="table table-hover align-middle">
                                <thead class="table-dark">
                                    <tr>
                                        <th style="width: 15%">Código</th>
                                        <th style="width: 15%">Nemónico</th>
                                        <th style="width: 30%">Descripción Cargo</th>
                                        <th style="width: 20%">Departamento</th>
                                        <th style="width: 20%" class="text-center">Acciones</th>
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
                <h5 class="modal-title fw-bold"><i class="bi bi-pencil-square"></i> Modificar Cargo</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                
                <input type="hidden" id="editCodigoCargo">
                
                <div class="mb-3">
                    <label class="form-label fw-semibold">Nombre Corto</label>
                    <input type="text" class="form-control text-uppercase" id="editNombreCargo" maxlength="3" required>
                </div>
                <div class="mb-3">
                    <label class="form-label fw-semibold">Nueva Descripción</label>
                    <input type="text" class="form-control" id="editDescripcionCargo" maxlength="255" required>
                </div>
                <div class="mb-3">
                    <label class="form-label fw-semibold">Departamento Relacionado</label>
                    <select class="form-select" id="editComboDepartamento" required>
                        </select>
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
<script src="${pageContext.request.contextPath}/js/cargos-crud.js"></script>
</body>
</html>
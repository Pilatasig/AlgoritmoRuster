<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.Calendar, java.text.SimpleDateFormat" %>
<%@ page import="java.util.Set, java.util.stream.Collectors" %>
<%
    Set<String> permisos = (Set<String>) session.getAttribute("permisos");
    boolean puedeP31 = permisos != null && permisos.contains("P31");
    String permisosJson = permisos != null ? "[" + permisos.stream().map(p -> "\"" + p + "\"").collect(Collectors.joining(",")) + "]" : "[]";
%>
<%
    Calendar cal = Calendar.getInstance();
    SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

    cal.add(Calendar.YEAR, -18);
    String fechaMaxNac = sdf.format(cal.getTime());

    cal = Calendar.getInstance();
    cal.add(Calendar.YEAR, -100);
    String fechaMinNac = sdf.format(cal.getTime());
%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - CRUD Empleados</title>
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
                <h2 class="fw-bold text-dark m-0">Gesti&oacute;n de Empleados</h2>
            </div>

            <div id="alertGlobal" class="alert d-none" role="alert"></div>

            <ul class="nav nav-tabs fw-bold mb-4" id="mainTab" role="tablist">
                <% if (puedeP31) { %>
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="tab-nuevo" data-bs-toggle="tab" data-bs-target="#panelNuevo" type="button" role="tab">
                        <i class="bi bi-person-plus-fill me-1"></i>Nuevo Registro
                    </button>
                </li>
                <% } %>
                <li class="nav-item" role="presentation">
                    <button class="nav-link <%= puedeP31 ? "" : "active" %>" id="tab-listado" data-bs-toggle="tab" data-bs-target="#panelListado" type="button" role="tab">
                        <i class="bi bi-list-ul me-1"></i>Listado
                    </button>
                </li>
            </ul>

            <div class="tab-content" id="mainTabContent">

                <div class="tab-pane fade <%= puedeP31 ? "show active" : "" %>" id="panelNuevo" role="tabpanel">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <form id="formEmpleado" novalidate>

                            <div class="alert alert-dark border-0 p-3 mb-4">
                                <h5 class="fw-bold text-white mb-3"><i class="bi bi-person-badge"></i> Datos Primarios Identificativos</h5>
                                <div class="row g-3">
                                    <div class="col-md-4">
                                        <label class="form-label text-white-50 small fw-bold">C&eacute;dula (Ecuador)</label>
                                        <input type="text" class="form-control form-control-lg fw-bold" id="empCedula" maxlength="10" required placeholder="Ej: 1721457890">
                                    </div>
                                    <div class="col-md-4">
                                        <label class="form-label text-white-50 small fw-bold">Nombres Completos</label>
                                        <input type="text" class="form-control form-control-lg" id="empNombres" required>
                                    </div>
                                    <div class="col-md-4">
                                        <label class="form-label text-white-50 small fw-bold">Apellidos Completos</label>
                                        <input type="text" class="form-control form-control-lg" id="empApellidos" required>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-9">
                                    <ul class="nav nav-pills mb-3 bg-light p-2 rounded" id="pills-tab" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <button class="nav-link active fw-bold" id="tab-generales" data-bs-toggle="tab" data-bs-target="#panelGenerales" type="button" role="tab">1. Datos Generales</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="nav-link fw-bold" id="tab-contacto" data-bs-toggle="tab" data-bs-target="#panelContacto" type="button" role="tab">2. Informaci&oacute;n de Contacto</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="nav-link fw-bold" id="tab-laboral" data-bs-toggle="tab" data-bs-target="#panelLaboral" type="button" role="tab">3. Informaci&oacute;n Laboral</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="nav-link fw-bold" id="tab-familiar" data-bs-toggle="tab" data-bs-target="#panelFamiliar" type="button" role="tab">4. Carga Familiar</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button class="nav-link fw-bold" id="tab-usuario" data-bs-toggle="tab" data-bs-target="#panelUsuario" type="button" role="tab">5. Usuario</button>
                                        </li>
                                    </ul>

                                    <div class="tab-content border p-4 bg-white rounded shadow-sm mb-4" id="pills-tabContent">
                                        
                                        <div class="tab-pane fade show active" id="panelGenerales" role="tabpanel">
                                            <div class="row g-3">
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold">Fecha de Nacimiento</label>
                                                    <input type="date" class="form-control" id="empFechaNac" required min="<%= fechaMinNac %>" max="<%= fechaMaxNac %>">
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold">Estado Civil</label>
                                                    <select class="form-select" id="empEstadoCivil">
                                                        <option value="S">Soltero/a</option>
                                                        <option value="C">Casado/a</option>
                                                        <option value="V">Viudo/a</option>
                                                        <option value="D">Divorciado/a</option>
                                                        <option value="U">Uni&oacute;n Libre</option>
                                                    </select>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold">Sexo</label>
                                                    <select class="form-select" id="empSexo">
                                                        <option value="M">Masculino</option>
                                                        <option value="F">Femenino</option>
                                                    </select>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold">¿Registra Discapacidad?</label>
                                                    <div class="form-check form-switch mt-2">
                                                        <input class="form-check-input" type="checkbox" id="empDiscapacidad" role="switch">
                                                        <label class="form-check-label fw-bold text-muted" for="empDiscapacidad" id="lblDiscapacidad">No</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                <div class="tab-pane fade" id="panelContacto" role="tabpanel">
                                    <div class="row g-3">
                                        <div class="col-md-6">
                                            <label class="form-label fw-semibold">Tel&eacute;fono de Contacto</label>
                                            <input type="text" class="form-control" id="empTelefono" maxlength="10" placeholder="Ej: 0998765432">
                                        </div>
                                        <div class="col-md-6">
                                            <label class="form-label fw-semibold">Correo Institucional</label>
                                            <input type="email" class="form-control" id="empCorreo" placeholder="ejemplo@monster.edu.ec" required>
                                        </div>
                                        <div class="col-12">
                                            <label class="form-label fw-semibold">Direcci&oacute;n Domiciliaria</label>
                                            <input type="text" class="form-control" id="empDireccion" placeholder="Av. Principal y Calle Secundaria">
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="panelLaboral" role="tabpanel">
                                    <div class="row g-3">
                                        <div class="col-md-4">
                                            <label class="form-label fw-semibold">Cargo de Ingreso</label>
                                            <select class="form-select" id="comboCargo" required>
                                                <option value="" selected disabled>Seleccione un cargo...</option>
                                            </select>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label fw-semibold">Superior Directo</label>
                                            <select class="form-select" id="comboSuperior">
                                                <option value="">-- Ninguno (Es Autoridad M&aacute;xima) --</option>
                                            </select>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label fw-semibold">Remuneraci&oacute;n Mensual</label>
                                            <input type="number" class="form-control" id="empSalario" step="0.01" required placeholder="0.00">
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="panelFamiliar" role="tabpanel">
                                    <div class="alert alert-info border-0 p-3 mb-3" id="msgGuardarPrimero">
                                        <i class="bi bi-info-circle me-2"></i>Guarde primero el empleado para gestionar sus familiares.
                                    </div>
                                    <input type="hidden" id="empCodigoGuardado">

                                    <div id="panelFamiliaresEmpleado" class="d-none">
                                        <div class="row g-3 mb-3">
                                            <div class="col-md-6">
                                                <label class="form-label fw-semibold small">Empleado</label>
                                                <input type="text" class="form-control form-control-sm bg-light fw-bold" id="empCodigoGuardadoDisplay" readonly>
                                            </div>
                                        </div>

                                        <div id="formFamiliarContainer" class="border p-3 bg-light rounded shadow-sm mb-3">
                                            <h6 class="fw-bold text-secondary mb-3"><i class="bi bi-person-plus-fill me-2"></i>Nuevo Familiar</h6>
                                            <div class="row g-3">
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold small">C&eacute;dula (Ecuador)</label>
                                                    <input type="text" class="form-control form-control-sm" id="famCedula" maxlength="10" required placeholder="Ej: 1721457890">
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold small">Nombres</label>
                                                    <input type="text" class="form-control form-control-sm" id="famNombres" required>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold small">Apellidos</label>
                                                    <input type="text" class="form-control form-control-sm" id="famApellidos" required>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold small">Fecha de Nacimiento</label>
                                                    <input type="date" class="form-control form-control-sm" id="famFechaNac" required>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label fw-semibold small">Sexo</label>
                                                    <select class="form-select form-select-sm" id="famSexo">
                                                        <option value="M">Masculino</option>
                                                        <option value="F">Femenino</option>
                                                    </select>
                                                </div>
                                                <div class="col-12">
                                                    <button type="button" class="btn btn-primary btn-sm fw-bold" id="btnGuardarFamiliar"><i class="bi bi-save me-1"></i>Guardar Familiar</button>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="familiaresContainer" class="d-none">
                                            <h6 class="fw-bold text-dark mb-3">Familiares Registrados</h6>
                                            <div class="table-responsive" style="max-height: 400px; overflow-y: auto;">
                                                <table class="table table-hover align-middle table-sm">
                                                    <thead class="table-dark" style="position: sticky; top: 0; z-index: 1;">
                                                        <tr>
                                                            <th>C&oacute;digo</th>
                                                            <th>C&eacute;dula</th>
                                                            <th>Nombres</th>
                                                            <th>Apellidos</th>
                                                            <th>Sexo</th>
                                                            <th>F. Nacimiento</th>
                                                            <th style="width: 18%" class="text-center">Acciones</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="tablaFamiliares">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="panelUsuario" role="tabpanel">
                                    <div class="border p-4 bg-light rounded shadow-sm">
                                        <h6 class="fw-bold text-secondary mb-3"><i class="bi bi-person-lock me-2"></i>Credenciales de Acceso</h6>
                                        <p class="text-muted small">Complete estos campos para crear autom&aacute;ticamente el usuario al guardar el empleado. Si deja las contrase&ntilde;as vac&iacute;as, no se crear&aacute; usuario.</p>
                                        <div class="row g-3">
                                            <div class="col-md-6">
                                                <label class="form-label fw-semibold">Contrase&ntilde;a</label>
                                                <input type="password" class="form-control" id="usuPassword" minlength="4" placeholder="M&iacute;nimo 4 caracteres">
                                            </div>
                                            <div class="col-md-6">
                                                <label class="form-label fw-semibold">Confirmar Contrase&ntilde;a</label>
                                                <input type="password" class="form-control" id="usuPasswordConfirm" placeholder="Repita la contrase&ntilde;a">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="card border-0 shadow-sm position-sticky" style="top: 1rem;">
                                <div class="card-body text-center">
                                    <h6 class="fw-bold text-secondary mb-3"><i class="bi bi-camera me-1"></i>Foto</h6>
                                    <img id="empPreviewFoto" src="" class="img-fluid rounded border mb-3 d-none"
                                         style="max-height: 200px; object-fit: cover; width: 100%;"
                                         alt="Vista previa">
                                    <input type="file" class="form-control form-control-sm" id="empFoto" accept="image/png, image/jpeg">
                                </div>
                            </div>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-success btn-lg fw-bold w-100"><i class="bi bi-save"></i> Guardar Ficha del Colaborador</button>
                        </form>
                    </div>
                </div>

                <div class="tab-pane fade <%= !puedeP31 ? "show active" : "" %>" id="panelListado" role="tabpanel">
                    <div class="card border-0 shadow-sm p-4 bg-white">
                        <div class="d-flex flex-column flex-sm-row justify-content-between align-items-sm-center mb-3 gap-2">
                            <h5 class="fw-bold text-dark m-0">Empleados Registrados</h5>
                            <div class="d-flex align-items-center gap-2" style="min-width: 250px;">
                                <label class="text-muted small fw-bold text-nowrap m-0">Buscar:</label>
                                <input type="text" class="form-control form-control-sm" id="inputBusqueda" placeholder="C&eacute;dula, nombre o c&oacute;digo...">
                            </div>
                        </div>
                        
                        <div class="table-responsive" style="max-height: 600px; overflow-y: auto;">
                            <table class="table table-hover align-middle table-sm">
                                <thead class="table-dark" style="position: sticky; top: 0; z-index: 1;">
                                    <tr>
                                        <th>C&oacute;digo</th>
                                        <th>C&eacute;dula</th>
                                        <th>Nombres</th>
                                        <th>Apellidos</th>
                                        <th>Salario</th>
                                        <th style="width: 22%" class="text-center">Acciones</th>
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
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content border-0 shadow">
            <div class="modal-header bg-warning text-dark">
                <h5 class="modal-title fw-bold"><i class="bi bi-pencil-square me-2"></i>Modificar Empleado</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body p-4">
                <input type="hidden" id="editCodigo">

                <div class="alert alert-dark border-0 p-2 mb-3">
                    <div class="row g-2 align-items-center">
                        <div class="col-md-3">
                            <label class="form-label text-white-50 small fw-bold m-0">C&eacute;dula</label>
                            <input type="text" class="form-control form-control-sm fw-bold bg-light" id="editCedula" maxlength="10" readonly>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label text-white-50 small fw-bold m-0">Nombres</label>
                            <input type="text" class="form-control form-control-sm" id="editNombres" required>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label text-white-50 small fw-bold m-0">Apellidos</label>
                            <input type="text" class="form-control form-control-sm" id="editApellidos" required>
                        </div>
                    </div>
                </div>

                <ul class="nav nav-pills mb-3 bg-light p-2 rounded" id="edit-pills-tab" role="tablist">
                    <li class="nav-item" role="presentation">
                        <button class="nav-link active fw-bold small" id="edit-tab-generales" data-bs-toggle="tab" data-bs-target="#editPanelGenerales" type="button" role="tab">1. Datos Generales</button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link fw-bold small" id="edit-tab-contacto" data-bs-toggle="tab" data-bs-target="#editPanelContacto" type="button" role="tab">2. Contacto</button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link fw-bold small" id="edit-tab-laboral" data-bs-toggle="tab" data-bs-target="#editPanelLaboral" type="button" role="tab">3. Laboral</button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link fw-bold small" id="edit-tab-familiar" data-bs-toggle="tab" data-bs-target="#editPanelFamiliar" type="button" role="tab">4. Carga Familiar</button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link fw-bold small" id="edit-tab-usuario" data-bs-toggle="tab" data-bs-target="#editPanelUsuario" type="button" role="tab">5. Usuario</button>
                    </li>
                </ul>

                <div class="tab-content" id="edit-pills-tabContent">
                    <div class="tab-pane fade show active" id="editPanelGenerales" role="tabpanel">
                        <div class="row g-3">
                            <div class="col-4">
                                <label class="form-label fw-semibold small">Estado Civil</label>
                                <select class="form-select form-select-sm" id="editEstadoCivil">
                                    <option value="S">Soltero/a</option>
                                    <option value="C">Casado/a</option>
                                    <option value="V">Viudo/a</option>
                                    <option value="D">Divorciado/a</option>
                                    <option value="U">Uni&oacute;n Libre</option>
                                </select>
                            </div>
                            <div class="col-4">
                                <label class="form-label fw-semibold small">Sexo</label>
                                <select class="form-select form-select-sm bg-light" id="editSexo" disabled>
                                    <option value="M">Masculino</option>
                                    <option value="F">Femenino</option>
                                </select>
                            </div>
                            <div class="col-4">
                                <label class="form-label fw-semibold small">Discapacidad</label>
                                <div class="form-check form-switch mt-3">
                                    <input class="form-check-input" type="checkbox" id="editDiscapacidad" role="switch">
                                    <label class="form-check-label small text-muted" for="editDiscapacidad" id="lblEditDiscap">No</label>
                                </div>
                            </div>
                            <div class="col-4">
                                <label class="form-label fw-semibold small">Foto</label>
                                <img id="editPreviewFoto" src="" class="img-fluid rounded border mb-3 d-none"
                                     style="max-height: 200px; object-fit: cover; width: 100%;"
                                     alt="Vista previa">
                                <input type="file" class="form-control form-control-sm" id="editFoto" accept="image/png, image/jpeg">
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="editPanelContacto" role="tabpanel">
                        <div class="row g-3">
                            <div class="col-6">
                                <label class="form-label fw-semibold small">Tel&eacute;fono</label>
                                <input type="text" class="form-control form-control-sm" id="editTelefono">
                            </div>
                            <div class="col-6">
                                <label class="form-label fw-semibold small">Correo</label>
                                <input type="email" class="form-control form-control-sm" id="editCorreo" required>
                            </div>
                            <div class="col-12">
                                <label class="form-label fw-semibold small">Direcci&oacute;n</label>
                                <input type="text" class="form-control form-control-sm" id="editDireccion">
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="editPanelLaboral" role="tabpanel">
                        <div class="row g-3">
                            <div class="col-12">
                                <label class="form-label fw-semibold small">C&oacute;digo Empleado</label>
                                <input type="text" class="form-control form-control-sm bg-light" id="editCodigoDisplay" readonly>
                            </div>
                            <div class="col-6">
                                <label class="form-label fw-semibold small">Cargo</label>
                                <select class="form-select form-select-sm" id="editComboCargo">
                                    <option value="" selected disabled>Seleccione un cargo...</option>
                                </select>
                            </div>
                            <div class="col-6">
                                <label class="form-label fw-semibold small">Superior Directo</label>
                                <select class="form-select form-select-sm" id="editComboSuperior">
                                    <option value="">-- Ninguno --</option>
                                </select>
                            </div>
                            <div class="col-6">
                                <label class="form-label fw-semibold small">Salario</label>
                                <input type="number" class="form-control form-control-sm" id="editSalario" step="0.01" required>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="editPanelFamiliar" role="tabpanel">
                        <form id="editFormFamiliar" class="border p-3 bg-light rounded shadow-sm mb-3">
                            <h6 class="fw-bold text-secondary mb-3"><i class="bi bi-person-plus-fill me-2"></i>Nuevo Familiar</h6>
                            <div class="row g-3">
                                <div class="col-md-4">
                                    <label class="form-label fw-semibold small">C&eacute;dula (Ecuador)</label>
                                    <input type="text" class="form-control form-control-sm" id="editFamCedulaNew" maxlength="10" required placeholder="Ej: 1721457890">
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label fw-semibold small">Nombres</label>
                                    <input type="text" class="form-control form-control-sm" id="editFamNombresNew" required>
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label fw-semibold small">Apellidos</label>
                                    <input type="text" class="form-control form-control-sm" id="editFamApellidosNew" required>
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label fw-semibold small">Fecha de Nacimiento</label>
                                    <input type="date" class="form-control form-control-sm" id="editFamFechaNacNew" required>
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label fw-semibold small">Sexo</label>
                                    <select class="form-select form-select-sm" id="editFamSexoNew">
                                        <option value="M">Masculino</option>
                                        <option value="F">Femenino</option>
                                    </select>
                                </div>
                                <div class="col-12">
                                    <button type="submit" class="btn btn-primary btn-sm fw-bold"><i class="bi bi-save me-1"></i>Guardar Familiar</button>
                                </div>
                            </div>
                        </form>
                        <div id="editFamiliaresContainer" class="d-none">
                            <h6 class="fw-bold text-dark mb-3">Familiares Registrados</h6>
                            <div class="table-responsive" style="max-height: 300px; overflow-y: auto;">
                                <table class="table table-hover align-middle table-sm">
                                    <thead class="table-dark" style="position: sticky; top: 0; z-index: 1;">
                                        <tr>
                                            <th>C&oacute;digo</th>
                                            <th>C&eacute;dula</th>
                                            <th>Nombres</th>
                                            <th>Apellidos</th>
                                            <th>Sexo</th>
                                            <th>F. Nacimiento</th>
                                            <th style="width: 18%" class="text-center">Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody id="editTablaFamiliares">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="editPanelUsuario" role="tabpanel">
                        <div id="editSinUsuarioContainer">
                            <div class="alert alert-warning border-0 p-3">
                                <i class="bi bi-exclamation-triangle me-2"></i>Este empleado no tiene un usuario registrado. Puede crearlo ahora.
                            </div>
                            <div class="border p-4 bg-light rounded shadow-sm">
                                <h6 class="fw-bold text-secondary mb-3"><i class="bi bi-person-lock me-2"></i>Crear Usuario</h6>
                                <div class="row g-3">
                                    <div class="col-md-6">
                                        <label class="form-label fw-semibold">Contrase&ntilde;a</label>
                                        <input type="password" class="form-control" id="editCrearUsuPassword" minlength="4" placeholder="M&iacute;nimo 4 caracteres">
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label fw-semibold">Confirmar Contrase&ntilde;a</label>
                                        <input type="password" class="form-control" id="editCrearUsuPasswordConfirm" placeholder="Repita la contrase&ntilde;a">
                                    </div>
                                    <div class="col-12">
                                        <button type="button" class="btn btn-success fw-bold" id="btnCrearUsuarioEdit">
                                            <i class="bi bi-person-check me-1"></i>Crear Usuario
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="editPanelUsuarioContent" class="d-none">
                            <div class="row g-3 mb-3">
                                <div class="col-md-6">
                                    <label class="form-label fw-semibold small">C&oacute;digo Empleado</label>
                                    <input type="text" class="form-control form-control-sm bg-light fw-bold" id="editUsuCodigoDisplay" readonly>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label fw-semibold small">Estado Actual</label>
                                    <div class="d-flex align-items-center gap-3 mt-1">
                                        <span class="badge fs-6" id="editUsuEstadoBadge">Activo</span>
                                        <button type="button" class="btn btn-sm btn-outline-secondary fw-bold" id="btnToggleEstado">
                                            <i class="bi bi-arrow-repeat me-1"></i>Cambiar Estado
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <div class="border p-4 bg-light rounded shadow-sm">
                                <h6 class="fw-bold text-secondary mb-3"><i class="bi bi-key me-2"></i>Cambiar Contrase&ntilde;a</h6>
                                <div class="row g-3">
                                    <div class="col-md-6">
                                        <label class="form-label fw-semibold">Nueva Contrase&ntilde;a</label>
                                        <input type="password" class="form-control" id="editUsuPassword" minlength="4" placeholder="M&iacute;nimo 4 caracteres">
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label fw-semibold">Confirmar Contrase&ntilde;a</label>
                                        <input type="password" class="form-control" id="editUsuPasswordConfirm" placeholder="Repita la contrase&ntilde;a">
                                    </div>
                                    <div class="col-12">
                                        <button type="button" class="btn btn-primary fw-bold" id="btnActualizarUsuario">
                                            <i class="bi bi-save me-1"></i>Guardar Cambios de Usuario
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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

<div class="modal fade" id="modalEditarFamiliar" data-bs-backdrop="static" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content border-0 shadow">
            <div class="modal-header bg-warning text-dark">
                <h5 class="modal-title fw-bold"><i class="bi bi-pencil-square me-2"></i>Modificar Familiar</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body p-4">
                <input type="hidden" id="editFamEmpleadoCodigo">
                <input type="hidden" id="editFamCodigo">

                <div class="alert alert-dark border-0 p-2 mb-3">
                    <div class="row g-2 align-items-center">
                        <div class="col-md-3">
                            <label class="form-label text-white-50 small fw-bold m-0">C&eacute;dula</label>
                            <input type="text" class="form-control form-control-sm fw-bold bg-light" id="editFamCedula" maxlength="10" readonly>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label text-white-50 small fw-bold m-0">Nombres</label>
                            <input type="text" class="form-control form-control-sm" id="editFamNombres" required>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label text-white-50 small fw-bold m-0">Apellidos</label>
                            <input type="text" class="form-control form-control-sm" id="editFamApellidos" required>
                        </div>
                    </div>
                </div>

                <div class="row g-3 mt-2">
                    <div class="col-md-4">
                        <label class="form-label fw-semibold small">Fecha de Nacimiento</label>
                        <input type="date" class="form-control form-control-sm" id="editFamFechaNac" required>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label fw-semibold small">Sexo</label>
                        <select class="form-select form-select-sm bg-light" id="editFamSexo" disabled>
                            <option value="M">Masculino</option>
                            <option value="F">Femenino</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="modal-footer bg-light">
                <button type="button" class="btn btn-secondary fw-semibold" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btn btn-success fw-bold px-4" onclick="guardarEdicionFamiliar()">
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
<script src="${pageContext.request.contextPath}/js/empleados-crud.js"></script>
</body>
</html>

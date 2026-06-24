<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.Set" %>
<%@ page import="java.util.stream.Collectors" %>
<%
    Set<String> permisos = (Set<String>) session.getAttribute("permisos");
    boolean puedeX31 = permisos != null && permisos.contains("X31");
    boolean puedeX33 = permisos != null && permisos.contains("X33");
    String permisosJson = permisos != null ? "[" + permisos.stream().map(p -> "\"" + p + "\"").collect(Collectors.joining(",")) + "]" : "[]";
%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Monster - Opciones por Perfil</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="${pageContext.request.contextPath}/css/global-layout.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    <style>
        .tree-sistema {
            background: #f8f9fa;
            border-left: 4px solid #0d6efd;
            padding: 10px 15px;
            margin-bottom: 8px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            user-select: none;
        }
        .tree-sistema:hover { background: #e9ecef; }
        .tree-sistema .toggle-icon { transition: transform .2s; }
        .tree-sistema .toggle-icon.collapsed { transform: rotate(-90deg); }
        .tree-opciones { padding-left: 24px; }

        .tree-modulo {
            margin-bottom: 6px;
            border: 1px solid #dee2e6;
            border-radius: 6px;
            background: #fff;
        }
        .tree-modulo-header {
            padding: 8px 12px;
            cursor: pointer;
            user-select: none;
            background: #f1f8f1;
            border-radius: 6px;
        }
        .tree-modulo-header:hover { background: #d9edda; }
        .toggle-icon-mod { transition: transform .2s; }
        .toggle-icon-mod.collapsed { transform: rotate(-90deg); }
        .tree-hijas { padding: 4px 12px 8px 36px; }
        .tree-hija { padding: 3px 0; }
        .tree-hija input[type="checkbox"] { cursor: pointer; width: 16px; height: 16px; }
        .tree-hija span { font-size: 0.9rem; }
    </style>
</head>
<body>

<div class="container-fluid p-0">
    <div class="row g-0">

        <jsp:include page="sidebar.jsp" />

        <div class="col-12 col-md-9 col-lg-10 main-content">

            <div class="d-flex justify-content-between align-items-center mb-4 bg-white p-3 rounded shadow-sm">
                <h2 class="fw-bold text-dark m-0">Opciones por Perfil</h2>
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
                    <% if (puedeX33) { %>
                    <div class="col-md-3">
                        <button class="btn btn-info w-100 fw-bold" onclick="cargarArbol()">
                            <i class="bi bi-search"></i> Consultar
                        </button>
                    </div>
                    <% } %>
                    <% if (puedeX31) { %>
                    <div class="col-md-3">
                        <button class="btn btn-success w-100 fw-bold" onclick="guardarAsignaciones()" id="btnGuardar" style="display:none;">
                            <i class="bi bi-save"></i> Guardar Cambios
                        </button>
                    </div>
                    <% } %>
                </div>
            </div>

            <div class="card border-0 shadow-sm bg-white" id="panelArbol" style="display:none;">
                <div class="card-header bg-dark text-white fw-bold">
                    <i class="bi bi-diagram-3"></i> &Aacute;rbol de Opciones
                    <span class="badge bg-light text-dark float-end" id="badgeOpciones">0</span>
                </div>
                <div class="card-body" id="arbolContainer"></div>
            </div>

        </div>
    </div>
</div>

<script>
    var PERMISOS = <%= permisosJson %>;
</script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script src="${pageContext.request.contextPath}/js/opciones-perfil.js"></script>
</body>
</html>
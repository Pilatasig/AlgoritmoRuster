<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.Set" %>
<%
    String uri = request.getRequestURI();
    Set<String> menus = (Set<String>) session.getAttribute("menusPermitidos");
    Set<String> permisos = (Set<String>) session.getAttribute("permisos");
    boolean tieneMenu = menus != null;
    boolean puedeReportes = permisos != null && (permisos.contains("P21") || permisos.contains("P22") || permisos.contains("P23") || permisos.contains("P24"));
    
    String activeInicio = uri.contains("menu") ? "active-mod" : "";
    String activeDepar = uri.contains("departamentos") ? "active-mod" : "";
    String activeCargos = uri.contains("cargos") ? "active-mod" : "";
    String activePerfi = uri.contains("perfiles") && !uri.contains("opciones-perfil") ? "active-mod" : "";
    String activeAsPer = uri.contains("asignar-perfiles") ? "active-mod" : "";
    String activeOpcPe = uri.contains("opciones-perfil") ? "active-mod" : "";
    String activeEmple = uri.contains("empleados") ? "active-mod" : "";
    String activeRepor = uri.contains("reportes") && !uri.contains("reportes-financieros") ? "active-mod" : "";
    String activeUsuarios = uri.contains("usuarios") ? "active-mod" : "";
    String activeFacturacion = uri.contains("facturacion") ? "active-mod" : "";
    String activePresupuestos = uri.contains("presupuestos") ? "active-mod" : "";
    String activeRepFinan = uri.contains("reportes-financieros") ? "active-mod" : "";
    String activeProyectos = uri.contains("proyectos") ? "active-mod" : "";
    String activeTareas = uri.contains("tareas") ? "active-mod" : "";
    String activeAsignaciones = uri.contains("asignaciones") ? "active-mod" : "";
%>
<div class="col-12 col-md-3 col-lg-2 sidebar d-flex flex-column p-3">
    <div class="sidebar-brand text-white text-center py-3 mb-3 fw-bold">
        <span class="text-primary">MÓDULO</span> MONSTER
    </div>

    <div class="text-center mb-3">
        <img src="${pageContext.request.contextPath}/api/empleados/<%= session.getAttribute("empleadoCodigo") != null ? session.getAttribute("empleadoCodigo") : "" %>/foto"
             class="rounded-circle border border-2 border-light"
             width="64" height="64"
             style="object-fit: cover;"
             onerror="this.style.display='none'">
        <div class="text-white small mt-1 fw-bold">
            <%= session.getAttribute("empleadoNombres") != null ? session.getAttribute("empleadoNombres") : "" %>
        </div>
    </div>
    
    <ul class="nav flex-column flex-grow-1">
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/menu" class="nav-link-menu <%= activeInicio %>">
                <span class="menu-icon-circle bg-light text-dark">H</span>
                Inicio / Panel
            </a>
        </li>
        <% if (tieneMenu && menus.contains("P01")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/departamentos" class="nav-link-menu <%= activeDepar %>">
                <span class="menu-icon-circle bg-primary text-white">D</span>
                Departamentos
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("P02")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/cargos" class="nav-link-menu <%= activeCargos %>">
                <span class="menu-icon-circle bg-success text-white">C</span>
                Cargos
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("P03")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/empleados" class="nav-link-menu <%= activeEmple %>">
                <span class="menu-icon-circle bg-warning text-white">E</span>
                Empleados
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("X01")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/perfiles" class="nav-link-menu <%= activePerfi %>">
                <span class="menu-icon-circle bg-info text-white">P</span>
                Perfiles
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("X02")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/asignar-perfiles" class="nav-link-menu <%= activeAsPer %>">
                <span class="menu-icon-circle bg-secondary text-white">AP</span>
                Asignar Perfiles
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("X03")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/opciones-perfil" class="nav-link-menu <%= activeOpcPe %>">
                <span class="menu-icon-circle bg-dark text-white">OP</span>
                Opciones por Perfil
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("X04")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/usuarios" class="nav-link-menu <%= activeUsuarios %>">
                <span class="menu-icon-circle bg-dark text-white">U</span>
                Usuarios
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("F01")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/facturacion" class="nav-link-menu <%= activeFacturacion %>">
                <span class="menu-icon-circle" style="background-color:#6f42c1;color:white;">F01</span>
                Facturación
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("F02")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/presupuestos" class="nav-link-menu <%= activePresupuestos %>">
                <span class="menu-icon-circle" style="background-color:#e83e8c;color:white;">F02</span>
                Presupuestos
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("F03")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/reportes-financieros" class="nav-link-menu <%= activeRepFinan %>">
                <span class="menu-icon-circle" style="background-color:#17a2b8;color:white;">F03</span>
                Reportes Financieros
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("G01")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/proyectos" class="nav-link-menu <%= activeProyectos %>">
                <span class="menu-icon-circle" style="background-color:#28a745;color:white;">G01</span>
                Proyectos
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("G02")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/tareas" class="nav-link-menu <%= activeTareas %>">
                <span class="menu-icon-circle" style="background-color:#20c997;color:white;">G02</span>
                Tareas
            </a>
        </li>
        <% } %>
        <% if (tieneMenu && menus.contains("G03")) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/asignaciones" class="nav-link-menu <%= activeAsignaciones %>">
                <span class="menu-icon-circle" style="background-color:#fd7e14;color:white;">G03</span>
                Asignaciones
            </a>
        </li>
        <% } %>
        <% if (puedeReportes) { %>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/reportes" class="nav-link-menu <%= activeRepor %>">
                <span class="menu-icon-circle bg-danger text-white">R</span>
                Reportes
            </a>
        </li>
        <% } %>
    </ul>
    
    <div class="mt-auto pt-4 border-top border-secondary">
        <a href="${pageContext.request.contextPath}/logout" class="btn btn-outline-danger w-100 btn-sm fw-bold py-2">
            Cerrar Sesión
        </a>
    </div>
</div>

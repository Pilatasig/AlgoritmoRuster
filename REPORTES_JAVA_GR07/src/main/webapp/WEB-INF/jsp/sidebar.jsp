<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%
    String uri = request.getRequestURI();
    String activeInicio = uri.contains("menu") ? "active-mod" : "";
    String activeDepar = uri.contains("departamentos") ? "active-mod" : "";
    String activeCargos = uri.contains("cargos") ? "active-mod" : "";
    String activeEmple = uri.contains("empleados") ? "active-mod" : "";
    String activeFamil = uri.contains("familiares") ? "active-mod" : "";
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
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/departamentos" class="nav-link-menu <%= activeDepar %>">
                <span class="menu-icon-circle bg-primary text-white">D</span>
                Departamentos
            </a>
        </li>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/cargos" class="nav-link-menu <%= activeCargos %>">
                <span class="menu-icon-circle bg-success text-white">C</span>
                Cargos de Trabajo
            </a>
        </li>
        <li class="nav-item">
            <a href="${pageContext.request.contextPath}/empleados" class="nav-link-menu <%= activeEmple %>">
                <span class="menu-icon-circle bg-warning text-white">E</span>
                Empleados
            </a>
        </li>
    </ul>
    
    <div class="mt-auto pt-4 border-top border-secondary">
        <a href="${pageContext.request.contextPath}/logout" class="btn btn-outline-danger w-100 btn-sm fw-bold py-2">
            Cerrar Sesión
        </a>
    </div>
</div>

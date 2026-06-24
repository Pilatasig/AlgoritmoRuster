package ec.edu.monster.controlador;

import jakarta.servlet.http.HttpSession;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class ViewController {

    @GetMapping("/")
    public String irAlLoginPorDefecto() {
        return "login";
    }

    @GetMapping("/login")
    public String mostrarLogin() {
        return "login"; 
    }

    @GetMapping("/registro")
    public String mostrarRegistro() {
        return "registro"; 
    }
    
    @GetMapping("/departamentos")   
    public String mostrarDepartamentos(){
        return "departamentos";
    }
    
    @GetMapping("/cargos")
    public String mostrarCargos(){
        return "cargos";
    }

    @GetMapping("/perfiles")
    public String mostrarPerfiles(){
        return "perfiles";
    }

    @GetMapping("/asignar-perfiles")
    public String mostrarAsignarPerfiles(){
        return "asignar-perfiles";
    }

    @GetMapping("/opciones-perfil")
    public String mostrarOpcionesPerfil(){
        return "opciones-perfil";
    }
    
    @GetMapping("/menu")
    public String mostrarMenuPrincipal(){
        return "menu";
    }

    @GetMapping("/empleados")
    public String mostrarEmpleados(){
        return "empleado";
    }

    @GetMapping("/reportes")
    public String mostrarReportes(){
        return "reportes";
    }

    @GetMapping("/usuarios")
    public String mostrarUsuarios(){
        return "en-construccion";
    }

    @GetMapping("/facturacion")
    public String mostrarFacturacion(){
        return "en-construccion";
    }

    @GetMapping("/presupuestos")
    public String mostrarPresupuestos(){
        return "en-construccion";
    }

    @GetMapping("/reportes-financieros")
    public String mostrarReportesFinancieros(){
        return "en-construccion";
    }

    @GetMapping("/proyectos")
    public String mostrarProyectos(){
        return "en-construccion";
    }

    @GetMapping("/tareas")
    public String mostrarTareas(){
        return "en-construccion";
    }

    @GetMapping("/asignaciones")
    public String mostrarAsignaciones(){
        return "en-construccion";
    }

    @GetMapping("/familiares")
    public String mostrarFamiliares(){
        return "redirect:/empleados";
    }

    @GetMapping("/logout")
    public String cerrarSesion(HttpSession session) {
        session.invalidate();
        return "redirect:/login";
    }
}
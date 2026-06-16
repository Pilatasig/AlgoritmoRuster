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
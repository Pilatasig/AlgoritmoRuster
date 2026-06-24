package ec.edu.monster;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import java.awt.Desktop;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;

@SpringBootApplication
public class ProyectoMonsterApplication {

    public static void main(String[] args) {
        SpringApplication.run(ProyectoMonsterApplication.class, args);
        
        // CÓDIGO PARA ABRIR EL NAVEGADOR AUTOMÁTICAMENTE
        try {
            System.setProperty("java.awt.headless", "false");
            if (Desktop.isDesktopSupported() && Desktop.getDesktop().isSupported(Desktop.Action.BROWSE)) {
                Desktop.getDesktop().browse(new URI("http://localhost:8085/"));
            }
        } catch (IOException | URISyntaxException e) {
            System.out.println("No se pudo abrir el navegador de forma automática: " + e.getMessage());
        }
    }
}
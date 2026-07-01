package ec.edu.monster.controlador.jpa;

import ec.edu.monster.servicios.jpa.CargoServicio;
import ec.edu.monster.servicios.jpa.EmpleadoServicio;
import ec.edu.monster.servicios.jpa.PdfService;

import org.springframework.http.*;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/reportes")
public class ReporteController {

    private final CargoServicio cargoServicio;
    private final EmpleadoServicio empleadoServicio;
    private final PdfService pdfService;

    public ReporteController(
            CargoServicio cargoServicio,
            EmpleadoServicio empleadoServicio,
            PdfService pdfService) {

        this.cargoServicio = cargoServicio;
        this.empleadoServicio = empleadoServicio;
        this.pdfService = pdfService;
    }

    @GetMapping("/cargos")
    public ResponseEntity<byte[]>
    reporteCargos()
            throws Exception {

        byte[] pdf =
            pdfService.generarReporteCargos(
                cargoServicio.listarCargos());

        return ResponseEntity.ok()
                .header(
                    HttpHeaders.CONTENT_DISPOSITION,
                    "attachment; filename=cargos.pdf")
                .contentType(
                    MediaType.APPLICATION_PDF)
                .body(pdf);
    }

    @GetMapping("/empleados")
    public ResponseEntity<byte[]>
    reporteEmpleados()
            throws Exception {

        byte[] pdf =
            pdfService.generarReporteEmpleados(
                empleadoServicio.listarTodos());

        return ResponseEntity.ok()
                .header(
                    HttpHeaders.CONTENT_DISPOSITION,
                    "attachment; filename=empleados.pdf")
                .contentType(
                    MediaType.APPLICATION_PDF)
                .body(pdf);
    }
}
package ec.edu.monster.pdf;

import com.lowagie.text.*;
import com.lowagie.text.pdf.*;

import ec.edu.monster.entidades.Cargo;
import java.util.List;

public class CargoPdf {

    public static void generar(
            Document document,
            List<Cargo> cargos)
            throws Exception {

        Font titulo =
            new Font(Font.HELVETICA, 18, Font.BOLD);

        Paragraph encabezado =
            new Paragraph("REPORTE DE CARGOS", titulo);

        encabezado.setAlignment(Element.ALIGN_CENTER);

        document.add(encabezado);

        document.add(new Paragraph(" "));

        PdfPTable tabla =
            new PdfPTable(5);

        tabla.setWidthPercentage(100);

        tabla.addCell("C\u00f3digo");
        tabla.addCell("Departamento");
        tabla.addCell("Cargo");
        tabla.addCell("Descripci\u00f3n");
        tabla.addCell("Empleados");

        for (Cargo cargo : cargos) {

            tabla.addCell(
                cargo.getCodigo());

            tabla.addCell(
                cargo.getDepartamento()
                    .getNombre());

            tabla.addCell(
                cargo.getNombre());

            tabla.addCell(
                cargo.getDescripcion());

            tabla.addCell(
                String.valueOf(
                    cargo.getAsignaciones()
                         .size()));
        }

        document.add(tabla);
    }
}

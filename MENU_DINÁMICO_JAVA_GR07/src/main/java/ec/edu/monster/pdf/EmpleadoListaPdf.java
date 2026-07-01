package ec.edu.monster.pdf;

import com.lowagie.text.*;
import com.lowagie.text.pdf.*;

import ec.edu.monster.entidades.jpa.Empleado;
import java.util.List;

public class EmpleadoListaPdf {

    public static void generar(
            Document document,
            List<Empleado> empleados)
            throws Exception {

        Font titulo =
            new Font(Font.HELVETICA, 18, Font.BOLD);

        Paragraph encabezado =
            new Paragraph("REPORTE DE EMPLEADOS", titulo);

        encabezado.setAlignment(Element.ALIGN_CENTER);

        document.add(encabezado);

        document.add(new Paragraph(" "));

        PdfPTable tabla =
            new PdfPTable(6);

        tabla.setWidthPercentage(100);

        tabla.addCell("C\u00f3digo");
        tabla.addCell("C\u00e9dula");
        tabla.addCell("Nombres");
        tabla.addCell("Apellidos");
        tabla.addCell("Tel\u00e9fono");
        tabla.addCell("Salario");

        for (Empleado emp : empleados) {

            tabla.addCell(emp.getCodigo());

            tabla.addCell(
                emp.getCedula() != null
                    ? emp.getCedula()
                    : "-");

            tabla.addCell(
                emp.getNombres() != null
                    ? emp.getNombres()
                    : "-");

            tabla.addCell(
                emp.getApellidos() != null
                    ? emp.getApellidos()
                    : "-");

            tabla.addCell(
                emp.getTelefono() != null
                    ? emp.getTelefono()
                    : "-");

            tabla.addCell(
                String.format("%.2f",
                    emp.getSalario()));
        }

        document.add(tabla);
    }
}

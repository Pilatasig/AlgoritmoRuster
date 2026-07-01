package ec.edu.monster.pdf;

import com.lowagie.text.*;
import com.lowagie.text.pdf.*;

import ec.edu.monster.entidades.jpa.Empleado;

public class EmpleadoPdf {

    public static void generar(
            Document document,
            Empleado emp)
            throws Exception {

        Font titulo =
            new Font(Font.HELVETICA, 18, Font.BOLD);

        Paragraph p =
            new Paragraph(
                "FICHA DEL EMPLEADO",
                titulo);

        p.setAlignment(Element.ALIGN_CENTER);

        document.add(p);

        document.add(new Paragraph(" "));

        PdfPTable tabla =
            new PdfPTable(2);

        tabla.setWidthPercentage(100);

        agregarFila(
            tabla,
            "C\u00f3digo",
            emp.getCodigo());

        agregarFila(
            tabla,
            "Nombres",
            emp.getNombres());

        agregarFila(
            tabla,
            "Apellidos",
            emp.getApellidos());

        agregarFila(
            tabla,
            "C\u00e9dula",
            emp.getCedula());

        agregarFila(
            tabla,
            "Correo",
            emp.getCorreo());

        agregarFila(
            tabla,
            "Tel\u00e9fono",
            emp.getTelefono());

        document.add(tabla);
    }

    private static void agregarFila(
            PdfPTable tabla,
            String etiqueta,
            String valor) {

        tabla.addCell(etiqueta);
        tabla.addCell(valor);
    }
}

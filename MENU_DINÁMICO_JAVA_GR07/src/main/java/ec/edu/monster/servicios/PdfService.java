package ec.edu.monster.servicios;

import com.lowagie.text.Document;
import com.lowagie.text.pdf.PdfWriter;

import ec.edu.monster.entidades.Cargo;
import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.pdf.CargoPdf;
import ec.edu.monster.pdf.EmpleadoListaPdf;

import org.springframework.stereotype.Service;

import java.io.ByteArrayOutputStream;
import java.util.List;

@Service
public class PdfService {

    public byte[] generarReporteCargos(
            List<Cargo> cargos)
            throws Exception {

        ByteArrayOutputStream baos =
            new ByteArrayOutputStream();

        Document document =
            new Document();

        PdfWriter.getInstance(
            document,
            baos);

        document.open();

        CargoPdf.generar(
            document,
            cargos);

        document.close();

        return baos.toByteArray();
    }

    public byte[] generarReporteEmpleados(
            List<Empleado> empleados)
            throws Exception {

        ByteArrayOutputStream baos =
            new ByteArrayOutputStream();

        Document document =
            new Document();

        PdfWriter.getInstance(
            document,
            baos);

        document.open();

        EmpleadoListaPdf.generar(
            document,
            empleados);

        document.close();

        return baos.toByteArray();
    }
}
package ec.edu.monster.entidades.mongo;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.Field;
import java.util.Date;
import lombok.Data;

/**
 * @author Usuario
 */

@Data
@Document(collection = "UsuarioEmpleado")
public class UsuarioEmpleadoDocumento {
    @Id
    private String id;

    // --- Campos de Usuario (JPA) ---
    // Usuario.id (PEEMP_CODIGO) se mapea como username
    @Field(name="username")
    private String username;

    // Usuario.password (XEUSU_PASWD)
    @Field(name="password")
    private String password;

    // Usuario.fechaCreacion (XEUSU_FECCRE)
    @Field(name="fecha_creacion")
    private Date fechaCreacion;

    // Usuario.fechaModificacion (XEUSU_FECMOD)
    @Field(name="fecha_modificacion")
    private Date fechaModificacion;

    // Usuario.pieFirma (XEUSU_PIEFIR)
    @Field(name="pie_firma")
    private String pieFirma;

    // Usuario.estado.codigo (XEEST_CODIGO) — simplificado como String
    @Field(name="estado_codigo")
    private String estadoCodigo;

    // Control de intentos fallidos
    @Field(name="intentos_fallidos")
    private int intentosFallidos;

    @Field(name="bloqueado_hasta")
    private Date bloqueadoHasta;

    // Concepto de rol (simplificado para MongoDB, no existe como campo directo en JPA)
    @Field(name="rol")
    private String rol;

    // --- Datos embebidos del Empleado (JPA) ---
    @Field(name="datos_empleado")
    private EmpleadoNoSQL datosEmpleado;

    @Data
    public static class EmpleadoNoSQL {
        // Empleado.codigo (PEEMP_CODIGO)
        private String codigo;

        // Empleado.cedula (PEEMP_CEDULA)
        private String cedula;

        // Empleado.nombres (PEEMP_NOMBRE)
        private String nombres;

        // Empleado.apellidos (PEEMP_APELLI)
        private String apellidos;

        // Empleado.fechaNacimiento (PEEMP_FECNAC)
        private Date fechaNacimiento;

        // Empleado.correo (PEEMP_EMAIL)
        private String correo;

        // Empleado.telefono (PEEMP_TELEF)
        private String telefono;

        // Empleado.direccion (PEEMP_DIREC)
        private String direccion;

        private float salario;

        private boolean discapacidad;

        private byte[] foto;

        @Field(name="superior_codigo")
        private String superiorCodigo;

        @Field(name="estado_civil_codigo")
        private String estadoCivilCodigo;

        @Field(name="sexo_codigo")
        private String sexoCodigo;
    }
}

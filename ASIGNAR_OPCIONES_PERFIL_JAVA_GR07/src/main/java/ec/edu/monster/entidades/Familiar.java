package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.Date;
import lombok.Data;

@Data
@Entity
@Table(name = "PEFAM_FAMILI")
public class Familiar implements Serializable {
    private static final long serialVersionUID = 1L;

    @EmbeddedId
    private FamiliarId id = new FamiliarId();

    @ManyToOne
    @JoinColumn(name = "PEEMP_CODIGO", referencedColumnName = "PEEMP_CODIGO", insertable = false, updatable = false)
    @JsonIgnoreProperties({"asignaciones", "superior", "estadoCivil", "sexo", "foto", "fotoBase64"})
    private Empleado empleado;

    @ManyToOne
    @JoinColumn(name = "PESEX_CODIGO", referencedColumnName = "PESEX_CODIGO")
    @JsonIgnoreProperties("empleados")
    private Sexo sexo;

    @Column(name = "PEFAM_CEDULA", length = 10, nullable = false)
    private String cedula;

    @Column(name = "PEFAM_APELLI", length = 20, nullable = false)
    private String apellidos;

    @Column(name = "PEFAM_NOMBRE", length = 20, nullable = false)
    private String nombres;

    @Temporal(TemporalType.DATE)
    @Column(name = "PEFAM_FENAC", nullable = false, columnDefinition = "DATE")
    private Date fechaNacimiento;
}

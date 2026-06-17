package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import lombok.Data;

@Data
@Entity
@Table(name = "PEASIG_ASIGNA")
public class AsignacionCargo implements Serializable {
    private static final long serialVersionUID = 1L;

    @EmbeddedId
    private AsignacionCargoId id = new AsignacionCargoId();

    @ManyToOne
    @MapsId("codigoEmpleado")
    @JoinColumn(name = "PEEMP_CODIGO", referencedColumnName = "PEEMP_CODIGO")
    @JsonIgnoreProperties("asignaciones")
    private Empleado empleado;

    @ManyToOne
    @JoinColumn(name = "PECAR_CODIGO", referencedColumnName = "PECAR_CODIGO", insertable = false, updatable = false)
    @JsonIgnoreProperties({"asignaciones", "departamento"})
    private Cargo cargo;
}

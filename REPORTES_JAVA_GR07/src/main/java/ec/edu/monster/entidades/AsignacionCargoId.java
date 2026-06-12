package ec.edu.monster.entidades;

import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;
import java.io.Serializable;
import java.util.Date;
import lombok.Data;

@Data
@Embeddable
public class AsignacionCargoId implements Serializable {
    private static final long serialVersionUID = 1L;

    @Column(name = "PEEMP_CODIGO", columnDefinition = "CHAR(8)", length = 8)
    private String codigoEmpleado;

    @Column(name = "PECAR_CODIGO", columnDefinition = "CHAR(6)", length = 6)
    private String codigoCargo;

    @Column(name = "PEASIG_FECINI", columnDefinition = "DATE")
    private Date fechaInicio;
}
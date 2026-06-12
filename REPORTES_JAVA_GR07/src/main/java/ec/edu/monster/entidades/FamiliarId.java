package ec.edu.monster.entidades;

import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;
import java.io.Serializable;
import lombok.Data;

@Data
@Embeddable
public class FamiliarId implements Serializable {
    private static final long serialVersionUID = 1L;

    @Column(name = "PEEMP_CODIGO", columnDefinition = "CHAR(6)", length = 6)
    private String codigoEmpleado;

    @Column(name = "PEFAM_CODIGO", columnDefinition = "CHAR(6)", length = 6)
    private String codigo;
}

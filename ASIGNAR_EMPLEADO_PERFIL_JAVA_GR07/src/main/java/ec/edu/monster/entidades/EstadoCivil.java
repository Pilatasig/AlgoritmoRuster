package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.List;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.ToString;

@Entity
@Table(name = "PEESC_ESTCIV")
@Data
public class EstadoCivil implements Serializable {

    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "PEESC_CODIGO", columnDefinition = "CHAR(1)", length = 1)
    private String codigo;

    @Column(name = "PEESC_DESCRI", nullable = false, length = 50)
    private String descripcion;

    @OneToMany(mappedBy = "estadoCivil")
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    @JsonIgnoreProperties("estadoCivil")
    private List<Empleado> empleados;
}

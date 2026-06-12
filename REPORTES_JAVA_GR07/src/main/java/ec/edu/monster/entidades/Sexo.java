package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.List;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.ToString;

@Entity
@Table(name = "PESEX_SEXO")
@Data
public class Sexo implements Serializable {

    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "PESEX_CODIGO", columnDefinition = "CHAR(1)", length = 1)
    private String codigo;

    @Column(name = "PESEX_DESCRI", nullable = false, length = 50)
    private String descripcion;

    @OneToMany(mappedBy = "sexo")
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    @JsonIgnoreProperties("sexo")
    private List<Empleado> empleados;
}

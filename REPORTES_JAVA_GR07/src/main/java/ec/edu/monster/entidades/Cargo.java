package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.List;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.ToString;

@Data
@Entity
@Table(name = "PECAR_CARGO")
public class Cargo implements Serializable {
    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "PECAR_CODIGO", columnDefinition = "CHAR(6)", length = 6)
    private String codigo;

    @Column(name = "PECAR_NOMBRE", nullable = false, length = 3)
    private String nombre;

    @Column(name = "PECAR_DESCRI", nullable = false, length = 255)
    private String descripcion;

    @ManyToOne
    @JoinColumn(name = "PEDEP_CODIGO", referencedColumnName = "PEDEP_CODIGO")
    @JsonIgnoreProperties("cargos")
    private Departamento departamento;

    @OneToMany(mappedBy = "cargo", fetch = FetchType.LAZY)
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    @JsonIgnoreProperties("cargo")
    private List<AsignacionCargo> asignaciones;
}

package ec.edu.monster.entidades.jpa;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import java.io.Serializable;
import java.util.List;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.ToString;

@Entity
@Table(name = "PEDEP_DEPAR")
@Data
public class Departamento implements Serializable {

    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "PEDEP_CODIGO", columnDefinition = "CHAR(6)", length = 6)
    private String codigo; 
    
    @Column (name="PEDEP_NOMBRE", columnDefinition = "CHAR(3)", length = 3)
    private  String nombre;

    @Column(name = "PEDEP_DESCRI", columnDefinition = "CHAR(50)", length = 50, nullable = false)
    private String descripcion; 
    
    @OneToMany(mappedBy="departamento", cascade=CascadeType.ALL, fetch = FetchType.LAZY)
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    @JsonIgnoreProperties("departamento")
    private List<Cargo> cargos;
}
package ec.edu.monster.entidades;

import jakarta.persistence.*;
import java.util.List;
import lombok.Data;


/**
 * * @author Usuario
 */
@Data
@Entity
@Table(name = "XEEST_ESTAD")
public class Estado {

    @Id    
    @Column(name = "XEEST_CODIGO", columnDefinition = "CHAR(1)", length = 1)
    private String codigo;

    @Column(name = "XEEST_DESCRI", nullable = false, length = 50)
    private String descripcion;
    
    @OneToMany(mappedBy = "estado", fetch = FetchType.LAZY)
    private List<Usuario> usuarios;  
}
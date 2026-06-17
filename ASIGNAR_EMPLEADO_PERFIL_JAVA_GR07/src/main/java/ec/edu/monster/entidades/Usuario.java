package ec.edu.monster.entidades;

import jakarta.persistence.*;
import java.io.Serializable;
import java.util.Date;
import lombok.Data;
import java.util.List;

/**
 * @author Usuario
 */
@Data
@Entity
@Table(name = "XEUSU_USUAR")
public class Usuario implements Serializable{
    
    @Id
    @Column(name = "PEEMP_CODIGO")
    private String id;
    
    @Column(name = "XEUSU_PASWD", length = 255)
    private String password;

    @Column(name = "XEUSU_FECCRE", nullable = false, columnDefinition = "DATE")
    private Date fechaCreacion;

    @Column(name = "XEUSU_FECMOD", columnDefinition = "DATE")
    private Date fechaModificacion;
    
    @Column(name = "XEUSU_PIEFIR", length = 100)
    private String pieFirma;

    @OneToOne(fetch = FetchType.LAZY)
    @MapsId //Necesario para decir que de aquí se saca el ID como String
    @JoinColumn(
        name = "PEEMP_CODIGO", 
        referencedColumnName = "PEEMP_CODIGO", 
        nullable = false,
        foreignKey = @ForeignKey(name = "FK_XEUSU_PEEMP")
    )
    private Empleado empleado;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "XEEST_CODIGO", 
        referencedColumnName = "XEEST_CODIGO", 
        nullable = false,
        foreignKey = @ForeignKey(name = "FK_XEUSU_XEEST")
    )
    private Estado estado;

    @OneToMany(mappedBy = "usuario", fetch = FetchType.LAZY)
    private List<Usuper> perfilesUsuario;
}
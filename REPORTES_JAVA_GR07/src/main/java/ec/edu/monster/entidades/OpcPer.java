package ec.edu.monster.entidades;

import jakarta.persistence.*;
import lombok.Data;
import java.util.Date;

/**
 * @author Usuario
 */
@Data
@Entity
@Table(name = "XEOXP_OPCPE")
@IdClass(OpcPerId.class)
public class OpcPer {
    
    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "XEOPC_CODIGO", 
        referencedColumnName = "XEOPC_CODIGO",
        foreignKey = @ForeignKey(name = "FK_XEOXP_XEOPC")
    )
    private Opcion opcion;
                                                                        
    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "XEPER_CODIGO", 
        referencedColumnName = "XEPER_CODIGO",
        foreignKey = @ForeignKey(name = "FK_XEOXP_XEPER")
    )
    private Perfil perfil;
    
    @Column(name="XEOXP_FECASI", columnDefinition = "DATE", nullable=false)
    private Date fechaAsignacion;
    
    @Column(name="XEOXP_FECRET", columnDefinition = "DATE")
    private Date fechaRetiro;
}
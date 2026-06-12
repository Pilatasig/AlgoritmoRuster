package ec.edu.monster.entidades;

import jakarta.persistence.*;
import lombok.Data;
import java.util.Date;

/**
 * @author Usuario
 */
@Data
@Entity
@Table(name = "XEUXP_USUPE")
@IdClass(UsuperId.class) 
public class Usuper {

    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "PEEMP_CODIGO", 
        referencedColumnName = "PEEMP_CODIGO",
        foreignKey = @ForeignKey(name = "FK_XEUXP_XEUSU")
    )
    private Usuario usuario;

    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "XEPER_CODIGO", 
        referencedColumnName = "XEPER_CODIGO",
        foreignKey = @ForeignKey(name = "FK_XEUXP_XEPER")
    )
    private Perfil perfil;
    
    @Column(name="XEUXP_FECASI", columnDefinition = "DATE", nullable=false)
    private Date fechaAsignacion;
    
    @Column(name="XEUXP_FECRET", columnDefinition = "DATE")
    private Date fechaRetiro;
}


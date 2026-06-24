package ec.edu.monster.entidades;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import lombok.Data;
import java.util.Date;

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
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "padre", "hijas", "opcionesPerfil", "sistema"})
    private Opcion opcion;
                                                                         
    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(
        name = "XEPER_CODIGO", 
        referencedColumnName = "XEPER_CODIGO",
        foreignKey = @ForeignKey(name = "FK_XEOXP_XEPER")
    )
    @JsonIgnoreProperties({"hibernateLazyInitializer", "handler", "opcionesPerfil", "perfilesUsuario"})
    private Perfil perfil;
    
    @Column(name="XEOXP_FECASI", columnDefinition = "DATE", nullable=false)
    private Date fechaAsignacion;
    
    @Column(name="XEOXP_FECRET", columnDefinition = "DATE")
    private Date fechaRetiro;
}
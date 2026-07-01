package ec.edu.monster.entidades.jpa;

import java.io.Serializable;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 *
 * @author Usuario
 */
@Data
@NoArgsConstructor
@AllArgsConstructor
public class OpcPerId implements Serializable {
    private static final long serialVersionUID=1l;
    
    private String opcion;
    private String perfil; 
}

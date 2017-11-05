# Pitanje 1:
Izvođenje programa je trajalo 5,004171 sekundi.

# Pitanje 2:
Operacije A, B, C, D i E su se izvodile na jednoj dretvi.

# Pitanje 3:
Sada je izvođenje programa trajalo 1,0304028 sekundi.

# Pitanje 4:
Operacije A, B, C, D i E ovaj put su se izvodile na pet dretvi.

# Pitanje 5:
Kada više dretvi radi sa istom varijablo često dolazi do hazarda (ako ne koristimo "locking" ili sinkronizaciju).
Npr. dretva 1 je dohvatila vrijednost varijable. No prije nego što ju je uspijela inkrementirati i vratiti natrag u varijablu, 
dretva 2 je dohvatila "staru" vrijednost varijable te nju inkrementirala i vratila natrag u varijablu čime se efektivno vrijednost varijable
povečala za 1 umjesto za 2.
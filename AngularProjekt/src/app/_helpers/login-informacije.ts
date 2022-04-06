export class LoginInformacije {
   autentifikacijaToken:       AutentifikacijaToken=null;
  isLogiran:                   boolean=false;
  isPermsijaKorisnik:          boolean=false;
  isPermsijaAdmin:             boolean=false;
}

export interface AutentifikacijaToken {
  id:                   number;
  vrijednost:           string;
  korisnickiNalogId:    number;
  korisnickiNalog:      KorisnickiNalog;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
}

export interface KorisnickiNalog {
  id:                 number;
  korisnickoIme:      string;
  isKorisnik:         boolean;
  isAdmin:            boolean;

}

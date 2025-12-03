export interface CriarHeroiExportDto {
  nome: string;
  nomeHeroi: string;
  dataNascimento: string | null;
  superPoderesIds: Array<number>;
  altura: number;
  peso: number;
}

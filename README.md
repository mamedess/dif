# 📊 dif — Contador de Linhas CLI

Uma ferramenta de linha de comando (CLI) rápida e extremamente leve para contar linhas de código em projetos de software. Construída em **C# / .NET 10**, ela varre seus diretórios de forma recursiva, lidando com pastas gigantes e arquivos bloqueados sem travar.

## 🚀 Funcionalidades

* **Performance Extrema:** usa *Streaming* e *Lazy Evaluation* (`File.ReadLines`), consumindo pouquíssima RAM mesmo em bases com gigabytes de código.
* **Busca Recursiva (DFS):** percorre toda a árvore de diretórios a partir do caminho informado.
* **Filtro por pasta e por extensão:** ignore diretórios de ruído (`.git`, `bin`, `obj`, `node_modules`…) com `--ignore` e restrinja a contagem a extensões específicas com `--ext`.
* **Arquitetura Defensiva:** arquivos travados pelo SO ou sem permissão (`IOException` / `UnauthorizedAccessException`) são pulados sem interromper o escaneamento.
* **Interface Moderna:** renderizada com `Spectre.Console` para um feedback visual limpo e colorido.

> ⚠️ **Importante:** por padrão a ferramenta conta **todos os arquivos com extensão**, inclusive binários (`.dll`, `.exe`, `.pdb`) e o conteúdo de `.git`. Não há blacklist automática — use `--ignore` e/ou `--ext` para um resultado limpo (veja os exemplos).

## 📦 Instalação / Build

Requisito: **.NET SDK 10**.

```bash
git clone https://github.com/mamedess/dif.git
cd dif
dotnet build -c Release
```

Para rodar via SDK durante o desenvolvimento:
```bash
dotnet run -c Release -- [CAMINHO] [opções]
```

Ou gere um executável standalone e use o binário `dif` diretamente:
```bash
dotnet publish -c Release -o ./publish
./publish/dif --help
```

## 💻 Como Usar

### Uso Básico
Analisa a partir da raiz do projeto (a primeira pasta acima que contém um `.csproj`); se não achar, usa o diretório atual:
```bash
dif
```

### Especificando um Caminho
```bash
dif ./meu-projeto-node
dif C:\Projetos\SistemaFinanceiro
```

### Ignorando Pastas (recomendado)
Separe os nomes das pastas por vírgula:
```bash
dif ./meu-projeto --ignore .git,bin,obj,node_modules
```

### Filtrando por Extensão
Conta apenas os tipos de arquivo informados:
```bash
dif ./meu-projeto --ext .cs,.ts
```

### Modo Detalhado
Lista cada arquivo lido no terminal:
```bash
dif ./meu-projeto --detalhes
```

### Exemplo completo (contagem limpa de C#)
```bash
dif . --ignore .git,bin,obj --ext .cs
```

## ⚙️ Opções e Comandos

```bash
dif --help
```

| Opção / Argumento | Atalho | Descrição |
| :--- | :--- | :--- |
| `[CAMINHO]` | - | **(Opcional)** Diretório a ser analisado. Se vazio, usa a raiz do projeto / diretório atual. |
| `--ignore <PASTAS>` | `-i` | Pastas a ignorar durante o escaneamento (separadas por vírgula). |
| `--ext <EXTENSOES>` | `-e` | Extensões a considerar (separadas por vírgula). Se vazio, conta todas. |
| `--detalhes` | `-d` | Mostra os arquivos lidos um a um no terminal. |
| `--help` | `-h`, `-?` | Exibe a tela de ajuda. |

---
*Construído com [Spectre.Console](https://spectreconsole.net/) e C#.*
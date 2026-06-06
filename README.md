# 📊 Contador de Linhas CLI

Uma ferramenta de linha de comando (CLI) rápida e extremamente leve para contar linhas de código em projetos de software. Construída em C# e .NET, ela varre seus diretórios de forma inteligente, lidando com pastas gigantes e arquivos bloqueados sem travar o seu computador.

## 🚀 Funcionalidades

* **Performance Extrema:** Utiliza *Streaming* e *Lazy Evaluation* (`File.ReadLines`). Consome quase zero de memória RAM, mesmo ao analisar gigabytes de código-fonte.
* **Busca Inteligente:** Navegação baseada em Busca em Profundidade (DFS), ignorando automaticamente o "ruído" do desenvolvimento (como `.git`, `.vs`, `node_modules`, `bin` e `obj`).
* **Arquitetura Defensiva:** Implementa *fallback* para pastas sem projetos e ignora arquivos travados pelo sistema operacional sem interromper o escaneamento.
* **Interface Moderna:** Renderizada com `Spectre.Console` para um feedback visual limpo e colorido.

## 💻 Como Usar

O uso foi desenhado para ser o mais simples possível. Você pode rodar a ferramenta dentro da pasta do seu código ou apontar para um diretório específico.

### Uso Básico
Para analisar a pasta exata onde o seu terminal está aberto agora:
```bash
dif
```

### Especificando um Caminho
Para analisar um projeto em outro lugar do seu computador:
```bash
dif ./meu-projeto-node
dif C:\Projetos\SistemaFinanceiro
```

### Ignorando Pastas Customizadas
A ferramenta já possui uma *blacklist* nativa de diretórios de sistema e bibliotecas. Se você quiser adicionar pastas específicas para serem ignoradas (como testes ou documentação), use a flag `-i` ou `--ignore` separando os nomes por vírgula:
```bash
dif ./meu-projeto --ignore tests,docs,assets
```

## ⚙️ Opções e Comandos

Se bater alguma dúvida no dia a dia, a própria CLI gera uma tela de documentação no seu terminal. Basta rodar:

```bash
dif --help
```

| Opção / Argumento | Atalho | Descrição |
| :--- | :--- | :--- |
| `[CAMINHO]` | - | **(Opcional)** O caminho do diretório que será analisado. Se vazio, usa o diretório atual. |
| `--ignore` | `-i` | Pastas extras para ignorar durante o escaneamento (separadas por vírgula). |
| `--help` | `-h`, `-?`| Exibe a tela de ajuda com todos os comandos disponíveis. |

---
*Construído com [Spectre.Console](https://spectreconsole.net/) e C#.*

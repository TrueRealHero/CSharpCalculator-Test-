# 1. Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# 2. Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# 3. Копируем всё остальное и собираем приложение
COPY . ./
RUN dotnet publish -c Release -o out

# 4. Используем официальный runtime-образ для запуска
FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app

# 5. Копируем собранное приложение из стадии build
COPY --from=build /app/out .

# 6. Запуск приложения
ENTRYPOINT ["dotnet", "MySecondTestAppCalculator.dll"]
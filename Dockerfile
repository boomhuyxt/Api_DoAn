# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Api_DoAn.slnx", "./"]
# Copy tất cả các file .csproj vào đúng thư mục của chúng
COPY . .
RUN dotnet restore "Api_DoAn.slnx"
RUN dotnet publish "Api_DoAn.slnx" -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Api_DoAn.dll"] 
# Lưu ý: Thay Api_DoAn.dll bằng tên file dll chính của bạn
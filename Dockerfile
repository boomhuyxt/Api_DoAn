# Giai đoạn Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy file solution và restore các gói NuGet
# Nếu file của bạn là Api_DoAn.slnx, hãy giữ nguyên. Nếu là .sln hãy sửa lại.
COPY ["Api_DoAn.slnx", "./"]
COPY . .
RUN dotnet restore "Api_DoAn.slnx"

# Build dự án
RUN dotnet build "Api_DoAn.slnx" -c Release -o /app/build

# Publish ứng dụng ra thư mục /app/publish
RUN dotnet publish "Api_DoAn.slnx" -c Release -o /app/publish /p:UseAppHost=false

# Giai đoạn Chạy (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# QUAN TRỌNG: Thay Api_DoAn.dll bằng tên file chạy thực tế của bạn nếu khác
ENTRYPOINT ["dotnet", "Api_DoAn.dll"]

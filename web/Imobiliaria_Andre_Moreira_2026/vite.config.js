import { defineConfig } from 'vite';
import laravel from 'laravel-vite-plugin';
import tailwindcss from '@tailwindcss/vite';

export default defineConfig({
    plugins: [
        laravel({
            input: ['resources/css/app.css', 'resources/js/app.js'],
            refresh: true,
        }),
        tailwindcss(),
    ],
    server: {
        host: '192.168.1.192', // Expõe o Vite para a tua rede local local
        cors: true,            // Permite que o Apache na porta 8080 aceda aos estilos na porta 5173
        watch: {
            ignored: ['**/storage/framework/views/**'],
        },
    },
});

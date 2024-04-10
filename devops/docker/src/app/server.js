import express from 'express';
import fetch from 'node-fetch';
import path from 'path';
import { fileURLToPath } from 'url';
import { dirname } from 'path';

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);


const app = express();

const PORT = process.env.PORT || 3000;
const API_HOST = process.env.API_HOST || 'localhost';
const API_PORT = process.env.API_PORT || 4000;

// Serve static files from the 'public' directory
app.use(express.static('public'));

// Endpoint to serve index.html
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, '/public/index.html'));
});

// Server-side endpoint to fetch random text
app.get('/random-text', async (req, res) => {
    try {
        const response = await fetch(`http://${API_HOST}:${API_PORT}/random-text`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const text = await response.text();
        res.send(text);
    } catch (error) {
        console.error('Failed to fetch random text:', error);
        res.status(500).send('Failed to fetch random text');
    }
});

app.get('/ping', (req, res) => {
    res.send('pong');
});

app.get('/health', (req, res) => {
    res.json({ status: 'UP' });
});

app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});

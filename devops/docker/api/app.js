const express = require('express');
const app = express();
const PORT = process.env.HTTP_PORT || 3000;

app.get('/random-text', (req, res) => {
    const randomTexts = ["Hello, world!", "Express is awesome!", "Node.js is cool!"];
    const randomIndex = Math.floor(Math.random() * randomTexts.length);
    res.send(randomTexts[randomIndex]);
});

app.get('/ping', (req, res) => {
    res.send('pong');
});

app.get('/health', (req, res) => {
    res.json({ status: 'UP' });
});

app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});

const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const TerserPlugin = require('terser-webpack-plugin');
const CompressionPlugin = require("compression-webpack-plugin");
const fs = require("fs");
const CopyPlugin = require("copy-webpack-plugin");

const pages = fs.readdirSync("./pages");

module.exports = {
    mode: "development",
    entry: pages.reduce((config, page) => {
        page = path.parse(page).name;
        config[page] = `./src/${page}.js`;
        return config;
    }, {}),
    output: {
        filename: "js/[name].min.js",
        path: path.resolve(__dirname, "dist"),
    },
    devServer: {
        static: "./dist",
    },
    module: {
        rules: [           
            {
                test: /\.css$/,
                exclude: /node_modules/,
                use: [
                    "style-loader",
                    "css-loader"
                ]
            }
        ]
    },
    plugins: [].concat(
        pages.map(
            (page) =>
                new HtmlWebpackPlugin({
                    inject: "head",
                    template: `./pages/${page}`,
                    filename: `${page}`,
                    chunks: [path.parse(page).name],
                })
        ),
        new CompressionPlugin({
            algorithm: "gzip",
            test: /\.(js|css)/
        }),
        new CopyPlugin({
            patterns: [{ from: "assets", to: "assets" }]
        }),
    ),
    optimization: {
        minimize: true,
        minimizer: [
            new TerserPlugin({
                parallel: true,
                extractComments: false,
            }),
        ],
        splitChunks: {
            chunks: 'all',
            minSize: 20000,
        },
    }
};
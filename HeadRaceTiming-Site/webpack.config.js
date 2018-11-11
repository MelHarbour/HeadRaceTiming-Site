const path = require('path');
const UglifyJsPlugin = require("uglifyjs-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

module.exports = [{
    entry: ['./wwwroot/src/site.js', './wwwroot/src/site.scss'],
    mode: 'production',
    output: {
        filename: 'site.js',
        path: path.resolve(__dirname, 'wwwroot/dist')
    },
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: 'site.css'
                        }
                    },
                    { loader: 'extract-loader' },
                    { loader: 'css-loader' },
                    {
                        loader: 'sass-loader',
                        options: {
                            includePaths: ['./node_modules']
                        },
                    }
                ]
            }
        ]
    }
}];
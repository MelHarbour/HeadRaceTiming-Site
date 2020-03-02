/// <binding BeforeBuild='Run - Production' />
const path = require('path');
const UglifyJsPlugin = require("uglifyjs-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

module.exports = [{
    entry: ['babel-polyfill', './wwwroot/src/site.scss', './wwwroot/src/components/timing-app.js'],
    mode: 'production',
    output: {
        filename: 'site.js',
        path: path.resolve(__dirname, 'wwwroot/dist'),
        publicPath: '/dist/'
    },
    optimization: {
        minimizer: [
            new UglifyJsPlugin({
                uglifyOptions: {
                    output: {
                        comments: false
                    }
                }
            })
        ]
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
                    'extract-loader',
                    'css-loader',
                    {
                        loader: 'sass-loader',
                        options: {
                            implementation: require('sass'),
                            sassOptions: {
                                includePaths: ['./node_modules']
                            }
                        },
                    }
                ]
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015', 'stage-2'],
                    plugins: ['transform-object-assign','transform-custom-element-classes']
                },
            }
        ]
    }
}];
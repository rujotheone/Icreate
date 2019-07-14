var path = require('path');
var webpack = require('webpack');

var config = {
   entry: './App/main.js',
   output: { path: __dirname, filename: 'index.js' },
   devServer: {
      inline: true,
      port: 7777,
      https: false,
      host:process.env.IP,
      compress: true,
      disableHostCheck: true
      
   },
   
   module: {
      loaders: [
         {
            test: /\.jsx?$/,
            exclude: /node_modules/,
            loader: 'babel-loader',
            query: {
               presets: ['es2015', 'react']
              }
         },
         { 
        test: /\.css$/, 
        loader: "style-loader!css-loader" 
        },
      { 
        test: /\.png$/, 
        loader: "url-loader?limit=100000" 
      },
      { 
        test: /\.jpg$/, 
        loader: "file-loader" 
      },
      {
        test: /\.(woff|woff2)(\?v=\d+\.\d+\.\d+)?$/, 
        loader: 'url-loader?limit=10000&mimetype=application/font-woff'
      },
      {
        test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, 
        loader: 'url-loader?limit=10000&mimetype=application/octet-stream'
      },
      {
        test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, 
        loader: 'file-loader'
      },
      {
        test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, 
        loader: 'url-loader?limit=10000&mimetype=image/svg+xml'
      }
      ]
   }
}
module.exports = config;
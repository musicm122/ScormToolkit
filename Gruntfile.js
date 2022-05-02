module.exports = function( grunt ){
    
    //1. configuration for grunt tasks that describe
    //how they should run and with what options
    grunt.initConfig({
        //do compass stuff
        compass : {
            options : {
                sassDir : 'scss',
                cssDir : 'css'
            },
            verbose : {
                options : {
                    outputStyle : 'expanded'
                }
            }
        },

        //only used for js files
        //compass compiles all of the css
        watch : {
            styles : {
                files : [ 'scss/*.scss' ],
                tasks : [ 'compass:verbose' ]
            }
        }
    });

    //2. Gives access to grunt tasks that have been loaded
    //through NPM
    //takes 1 argument: a string name for the NPM package
    //grunt.loadNpmTasks();
    grunt.loadNpmTasks( "grunt-contrib-compass" );
    grunt.loadNpmTasks( "grunt-contrib-watch" );


    //3. Specify the name of tasks to call
    //through iterm
    //takes 2 arguments:
    //1. string name of task
    //2. an array of tasks to run 
    //grunt.registerTask();
    grunt.registerTask( "default", [ "watch" ] );

};







set(LIBRARY_NAME protobuf314)
set(LIBRARY_PROTOBUF_3_14_0 ${LIBRARY_NAME} CACHE STRING "protobuf314.lib")

# Find all the input files
FILE(GLOB_RECURSE LIBRARY_SRCS "${CMAKE_CURRENT_SOURCE_DIR}/Source/Protobuf/Private/*.cc")

add_library(${LIBRARY_NAME} STATIC
        ${LIBRARY_SRCS}
        )
# include additionals headers
set(ADDITIONAL_INCLUDE_DIRS
        "${CMAKE_CURRENT_SOURCE_DIR}/Source/Protobuf/Public"
        )
target_include_directories(${LIBRARY_NAME}
        PUBLIC ${ADDITIONAL_INCLUDE_DIRS}
        )